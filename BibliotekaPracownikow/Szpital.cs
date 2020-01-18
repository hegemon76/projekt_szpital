using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPracownikow
{
    [Serializable]
    public class Szpital
    {
        public List<Czlowiek> ListaPracownikow = new List<Czlowiek>();
        public List<List<Czlowiek>> listaDyzurow = new List<List<Czlowiek>>();

        public void DodajPracownika(Czlowiek oCzlowiek)
        {
            ListaPracownikow.Add(oCzlowiek);
        }
        public void UsunPracownika(int numerPracownika)
        {
            ListaPracownikow.RemoveAt(numerPracownika - 1);
        }
        public void UstawGrafik()
        {
            listaDyzurow.Clear();
            resetujDyzury();
            int przydzielonePielegniarki = 0;
            int ilePielegniarek = 0;
            int maxPielegniarek;
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            string specjalizacja;
            int ileDniMaMiesiac = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            for (int i = 0; i < ileDniMaMiesiac; i++)
            {
                DateTime dt = new DateTime(year, month, i + 1);
                int kardiolog = 0;
                int urolog = 0;
                int neurolog = 0;
                int laryngolog = 0;
                listaDyzurow.Add(new List<Czlowiek>());
                for (int j = 0; j < ListaPracownikow.Count(); j++)
                {
                    var lekarz = ListaPracownikow.ElementAt(j) as Lekarz;
                    if (lekarz != null)
                    {
                        specjalizacja = lekarz.Specjalizacja.ToUpper();
                        if (lekarz.ileDyzurow == 10 || lekarz.dniPodRzad == 1)
                        {
                            lekarz.dniPodRzad = 0;
                            continue;
                        }
                        if (specjalizacja == "KARDIOLOG" && kardiolog >= 1) continue;
                        else if (specjalizacja == "UROLOG" && urolog >= 1) continue;
                        else if (specjalizacja == "LARYNGOLOG" && laryngolog >= 1) continue;
                        else if (specjalizacja == "NEUROLOG" && neurolog >= 1) continue;
                        sprawdzanieCzyDanyLekarzIstnieje(specjalizacja, ref kardiolog, ref urolog, ref neurolog, ref laryngolog);

                        listaDyzurow[i].Add(lekarz);
                        lekarz.dniPodRzad++;
                        lekarz.ileDyzurow++;
                        lekarz.Dyzury.Add(dt);
                        if (j == ListaPracownikow.Count() - 1)
                        {
                            kardiolog = 0;
                            neurolog = 0;
                            urolog = 0;
                            laryngolog = 0;
                        }
                    }
                    else
                    {
                        ilePielegniarek++;
                        if (ilePielegniarek > 2) maxPielegniarek = ilePielegniarek / 2;
                        else maxPielegniarek = ilePielegniarek;

                        var pielegniarka = ListaPracownikow.ElementAt(j) as Pielegniarka;

                        if (pielegniarka.dniPodRzad == 1 || pielegniarka.ileDyzurow == 10 || przydzielonePielegniarki >= maxPielegniarek)
                        {
                            pielegniarka.dniPodRzad = 0;
                            continue;
                        }
                        listaDyzurow[i].Add(pielegniarka);
                        przydzielonePielegniarki++;
                        pielegniarka.ileDyzurow++;
                        pielegniarka.dniPodRzad++;
                        pielegniarka.Dyzury.Add(dt);
                        if (j == ListaPracownikow.Count() - 1) przydzielonePielegniarki = 0;
                    }
                }
            }
        }
        private static void sprawdzanieCzyDanyLekarzIstnieje(string specjalizacja, ref int kardiolog, ref int urolog, ref int neurolog, ref int laryngolog)
        {
            if (specjalizacja == "KARDIOLOG") kardiolog++;
            if (specjalizacja == "LARYNGOLOG") laryngolog++;
            if (specjalizacja == "UROLOG") urolog++;
            if (specjalizacja == "NEUROLOG") neurolog++;
        }
        private void resetujDyzury()
        {

            foreach (var oPracownik in ListaPracownikow)
            {
                var lekarz = oPracownik as Lekarz;
                var pielegniarka = oPracownik as Pielegniarka;
                if (lekarz != null)
                {
                    lekarz.ileDyzurow = 0;
                    lekarz.dniPodRzad = 0;
                    lekarz.Dyzury.Clear();
                }
                else
                {
                    pielegniarka.ileDyzurow = 0;
                    pielegniarka.dniPodRzad = 0;
                    pielegniarka.Dyzury.Clear();
                }

            }
        }
        public void WyswietlGrafik()
        {
            if (listaDyzurow.Count() == 0) Console.WriteLine("Brak ustalonego grafiku");
            else
            {
                int ileDniMaMiesiac = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
                int rok = DateTime.Now.Year;
                int miesiac = DateTime.Now.Month;
                int dzien = 1;
                for (int i = 0; i < ileDniMaMiesiac; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Data: {dzien}.{miesiac}.{rok}");
                    foreach (var o in listaDyzurow[i])
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"{o.PrzedstawSieDlaInnych()}\n\n");
                    }
                    dzien++;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void WyswietlGrafikDanegoPracownika(int nrPracwnika)
        {
            for (int i = 0; i < ListaPracownikow.Count(); i++)
            {
                var lekarz = ListaPracownikow[i] as Lekarz;
                if (lekarz != null && nrPracwnika - 1 == i) lekarz.WyswietlGrafik();
                else if (i == nrPracwnika - 1)
                {
                    var pielegniarka = ListaPracownikow[i] as Pielegniarka;
                    pielegniarka.WyswietlGrafik();
                }
            }
        }
        public void WyswietlPracownikow()
        {
            int licznik = 1;
            foreach (var oPracownik in ListaPracownikow)
            {
                Console.WriteLine($"{licznik}.{oPracownik.PrzedstawSieDlaInnych()}");
                licznik++;
            }
        }
        public void WyswietlPracownikowAdminowi()
        {
            int licznik = 1;
            foreach (var oPracownik in ListaPracownikow)
            {
                Console.WriteLine($"{licznik}.{oPracownik.PrzedstawSieDlaAdmina()}\n");
                licznik++;
            }
        }
        public void UsunDyzur(int dzienMiesiaca, int nrDyzuru)
        {
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dzienMiesiaca);
            for (int i = 0; i < listaDyzurow.Count(); i++)
            {
                if (i == dzienMiesiaca - 1)
                {
                    for (int j = 0; j < listaDyzurow[i].Count(); j++)
                    {
                        if (nrDyzuru > listaDyzurow[i].Count()) Console.WriteLine("Takiego dyzuru nie ma w bazie");
                        else if (j == nrDyzuru - 1)
                        {
                            var lekarz = listaDyzurow[i].ElementAt(j) as Lekarz;
                            var pielegniarka = listaDyzurow[i].ElementAt(j) as Pielegniarka;
                            listaDyzurow[i].RemoveAt(j);
                            if (lekarz != null) lekarz.UsunDyzur(dt);
                            else if (pielegniarka != null) pielegniarka.UsunDyzur(dt);
                        }

                    }
                }
            }
        }
        public void DodajDyzur(int dzienMiesiaca, int nrPracownika, int dniWMiesiacu)
        {
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dzienMiesiaca);
            for (int i = 0; i < dniWMiesiacu; i++)
            {
                if (listaDyzurow.Count() <= dniWMiesiacu) listaDyzurow.Add(new List<Czlowiek>());
                if (i == dzienMiesiaca - 1)
                {

                    var lekarz = ListaPracownikow.ElementAt(nrPracownika - 1) as Lekarz;
                    var pielegniarka = ListaPracownikow.ElementAt(nrPracownika - 1) as Pielegniarka;
                    if (lekarz != null)
                    {
                        listaDyzurow[i].Add(lekarz);
                        lekarz.DodajDyzur(dt);
                        Console.WriteLine("Pomyslnie dodano pracownika");
                    }
                    else if (pielegniarka != null)
                    {
                        listaDyzurow[i].Add(pielegniarka);
                        pielegniarka.DodajDyzur(dt);
                        Console.WriteLine("Pomyslnie dodano pracownika");
                    }
                }
            }
        }
    }//class
}
