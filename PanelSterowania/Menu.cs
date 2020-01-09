using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaPracownikow;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace PanelSterowania
{
    class Menu
    {
        static void Main(string[] args)
        {
            Szpital szp = new Szpital();
            Czlowiek czlowiek = new Lekarz("janek", "kowalski", 123, 3456, "kardiolog", false, "123");
            Czlowiek czlowiek1 = new Lekarz("andrze", "kow", 123, 3456, "Kardiolog", false, "123");
            Czlowiek czlowiek2 = new Lekarz("dimitr", "nowak", 123, 3456, "Kardiolog", false, "123");
            Czlowiek czlowiek3 = new Lekarz("janusz", "luj", 123, 3456, "kardiolog", false, "123");
            Czlowiek czlowiek4 = new Lekarz("milosz", "kamlot", 123, 3456, "laryngolog", false, "123");
            Czlowiek czlowiek5 = new Lekarz("adam", "adamek", 123, 3456, "laryngolog", false, "123");
            Czlowiek czlowiek6 = new Lekarz("eeeee", "eeeee", 123, 3456, "Neurolog", false, "123");
            Czlowiek czlowiek7 = new Lekarz("ccccc", "acccdamek", 123, 3456, "Neurolog", false, "123");
            Czlowiek czlowiek8 = new Pielegniarka("ddd", "ddd", 123, false, "123");
            Czlowiek czlowiek9 = new Pielegniarka("ccc", "ccccc", 123, false, "123");
            Czlowiek czlowiek10 = new Pielegniarka("bbbb", "bbbb", 123, false, "123");
            Czlowiek czlowiek11 = new Pielegniarka("aaaa", "aaaa", 123, false, "123");
            Czlowiek czlowiek12 = new Pielegniarka("111111", "11111", 123, false, "123");
            Czlowiek czlowiek13 = new Pielegniarka("222222", "22222", 123, false, "123");
            Czlowiek czlowiek14 = new Pielegniarka("3333", "33333", 123, false, "123");
            szp.DodajPracownika(czlowiek);
            szp.DodajPracownika(czlowiek1);
            szp.DodajPracownika(czlowiek2);
            szp.DodajPracownika(czlowiek3);
            szp.DodajPracownika(czlowiek4);
            szp.DodajPracownika(czlowiek5);
            szp.DodajPracownika(czlowiek6);
            szp.DodajPracownika(czlowiek7);
            szp.DodajPracownika(czlowiek8);
            szp.DodajPracownika(czlowiek9);
            szp.DodajPracownika(czlowiek10);
            szp.DodajPracownika(czlowiek11);
            szp.DodajPracownika(czlowiek12);
            szp.DodajPracownika(czlowiek13);
            szp.DodajPracownika(czlowiek14);
            //List<List<Czlowiek>> listaDyzurow = new List<List<Czlowiek>>();


            //Console.WriteLine(szp.liczbaPracownikow);
            //listaDyzurow.Add(new List<Czlowiek>());
            //listaDyzurow[0].Add(czlowiek);
            //listaDyzurow[0].Add(czlowiek1);
            // szp.UstawGrafik();
            // szp.ustawGrafikPielegniarek();
            //szp.WyswietlGrafik();
            //ustawGrafikLekarzy(szp, listaDyzurow);
            //WyswietlGrafik(listaDyzurow);
            //szp.WyswietlPracownikow();
            // szp.UsunPracownika(podajLiczbe("Ktorego pracownika usuwamy? ", 1, szp.ListaPracownikow.Count()));
            //szp.WyswietlPracownikow();
            // szp.UstawGrafik();
            // szp.WyswietlGrafik();
            //MenuSzpitala(szp);
            WyswietlPliki();
        }
        protected const string specjalizacjaLekarza = "1.Kardiolog\n2.Urolog\n3.Neurolog\n4.Laryngolog";
        protected const string menuAplikacji = "1.Dodaj Pracownika\n2.Usun Pracownika\n3.Wyswietl Pracownikow\n4.Edytuj dane pracownika" +
            "\n5.Ustal grafik dla lekarzy i pielegniarek\n6.Wyswietl grafiki\n7.Wyswietl grafik pracownika" +
            "\n8.Zapisz liste pracownikow\n9.Odczytaj liste pracownikow\n10.Usun dyzur\n11.Dodaj dyzur\n12.wyjscie";

        public static void MenuSzpitala(Szpital szpital)
        {
            deserializuj(szpital);
            deserializujGrafiki(szpital);
            int ileDniMaMiesiac = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            int wyborMenu;
            do
            {
                wyborMenu = podajLiczbe(menuAplikacji, 1, 12);
                Console.Clear();
                switch (wyborMenu)
                {
                    case 1:
                        szpital.DodajPracownika(UtworzPracownika());
                        break;
                    case 2:
                        szpital.WyswietlPracownikow();
                        szpital.UsunPracownika(podajLiczbe("Ktorego pracownika usuwamy? ", 1, szpital.ListaPracownikow.Count()));
                        break;
                    case 3:
                        szpital.WyswietlPracownikow();
                        break;
                    case 4:
                        szpital.WyswietlPracownikow();
                        EdytujDane(szpital);
                        break;
                    case 5:
                        szpital.UstawGrafik();
                        Console.WriteLine("Grafik ustalono");
                        break;
                    case 6:
                        szpital.WyswietlGrafik();
                        break;
                    case 7:
                        szpital.WyswietlPracownikow();
                        szpital.WyswietlGrafikDanegoPracownika(podajLiczbe("Ktora osobe wybierasz? ", 1, szpital.ListaPracownikow.Count()));
                        break;
                    case 8:
                        serializuj(szpital);
                        break;
                    case 9:
                        deserializuj(szpital);
                        break;
                    case 10:
                        szpital.WyswietlGrafik();
                        int dzienMiesiaca = podajLiczbe("Podaj dzien miesiaca", 1, ileDniMaMiesiac);
                        int nrDyzuru = podajLiczbe("podaj nr dyzuru", 1, szpital.listaDyzurow[dzienMiesiaca - 1].Count());
                        szpital.UsunDyzur(dzienMiesiaca, nrDyzuru);
                        break;
                    case 11:
                        szpital.WyswietlPracownikow();
                        int nrPracownika = podajLiczbe("Podaj nr pracownika", 1, szpital.ListaPracownikow.Count());
                        int gdzieDodac = podajLiczbe("Podaj dzien do ktorego chcesz dodac pracownika", 1, ileDniMaMiesiac);
                        szpital.DodajDyzur(gdzieDodac, nrPracownika, ileDniMaMiesiac);
                        break;
                    case 12:
                        serializuj(szpital);
                        serializujGrafiki(szpital);
                        Console.WriteLine("Dane zostały zapisane, dziekuje za skorzystanie z programu");
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            } while (wyborMenu != 12);
        }

        public static Czlowiek UtworzPracownika()
        {
            string imie, nazwisko, specjalizacja;
            int pesel, pwz;
            Czlowiek pracownik;
            imie = podajTekst("Podaj imie: ");
            nazwisko = podajTekst("Podaj nazwisko: ");
            pesel = podajLiczbe("Podaj pesel: ");
            if (pytanieTlubN("Czy uzytkownik to admin?<T/N>"))
            {
                return pracownik = new Administrator(imie, nazwisko, pesel, true, "123");
            }
            else if (pytanieTlubN("Czy chcesz podac specjalizacje?<T/N>"))
            {
                specjalizacja = podajSpecjalizacje("Wybierz specjalizacje");
                pwz = podajLiczbe("Podaj nr PWZ: ");
                return pracownik = new Lekarz(imie, nazwisko, pesel, pwz, specjalizacja, false, "123");
            }
            else return pracownik = new Pielegniarka(imie, nazwisko, pesel, false, "123");
        }
        public static void EdytujDane(Szpital szpital)
        {
            int licznik = 0;
            int wybor = podajLiczbe("Ktorego pracownika chcesz edytowac?", 1, szpital.ListaPracownikow.Count());
            foreach (var oPracownik in szpital.ListaPracownikow)
            {
                var lekarz = oPracownik as Lekarz;
                var pielegniarka = oPracownik as Pielegniarka;
                if (lekarz != null && licznik == wybor - 1)
                {
                    string imie = podajTekst("Podaj nowe imie", 0);
                    string nazwisko = podajTekst("Podaj nowe nazwisko", 0);
                    int pesel = podajLiczbe("Podaj nowy pesel [0] zostawia poprzednią wartość", 0);
                    int pwz = podajLiczbe("Podaj nowe PWZ, [0] zostawia poprzednią wartość", 0);
                    string specjalizacja = podajSpecjalizacje("Wybierz nową specjalizacje");
                    lekarz.EdytujDane(imie, nazwisko, pesel, pwz, specjalizacja);
                }
                else if (pielegniarka != null && licznik == wybor - 1)
                {
                    string imie = podajTekst("Podaj nowe imie", 0);
                    string nazwisko = podajTekst("Podaj nowe nazwisko", 0);
                    int pesel = podajLiczbe("Podaj nowy pesel [0] zostawia poprzednią wartość", 0);
                    pielegniarka.EdytujDane(imie, nazwisko, pesel);
                }
                licznik++;
            }
            Console.WriteLine("Poprawnie wyedytowano dane");
        }
        protected static string podajSpecjalizacje(string msg)
        {
            string specjalizacja = null;
            do
            {
                Console.WriteLine(msg);
                int liczba = podajLiczbe(specjalizacjaLekarza, 1, 4);
                switch (liczba)
                {
                    case 1:
                        specjalizacja = "Kardiolog";
                        return specjalizacja;
                    case 2:
                        specjalizacja = "Urolog";
                        return specjalizacja;
                    case 3:
                        specjalizacja = "Neurolog";
                        return specjalizacja;
                    case 4:
                        specjalizacja = "Laryngolog";
                        return specjalizacja;
                    default:
                        Console.WriteLine("Liczba powinna zawierać sie w zakresie <1-4>");
                        specjalizacja = null;
                        break;
                }
            } while (specjalizacja != null);
            return specjalizacja;
        }
        protected static string podajTekst(string msg, int minimalnaDlugosc = 3)
        {
            string input;
            do
            {
                Console.WriteLine(msg);
                input = Console.ReadLine();
            } while (input.Length <= minimalnaDlugosc);
            return input;
        }
        protected static int podajLiczbe(string msg, int min = 1, int max = int.MaxValue)
        {
            int liczba;
            string input;
            do
            {
                Console.WriteLine(msg);
                input = Console.ReadLine();
            } while (!int.TryParse(input, out liczba) || liczba < min || liczba > max);
            return liczba;
        }
        protected static bool pytanieTlubN(string msg)
        {
            string input;
            Console.WriteLine(msg);
            input = Console.ReadLine();
            if (input.ToUpper() == "TAK" || input.ToUpper() == "T") return true;
            else return false;
        }
        static void serializuj(Szpital szpital)
        {
            FileStream fs = new FileStream("SZPITAL.dat", FileMode.Create);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, szpital.ListaPracownikow);
                bf.Serialize(fs, szpital.listaDyzurow);
            }
            catch (SerializationException e)
            {
                Console.WriteLine($"Nie udało się ponieważ {e.Message}");
                throw;
            }
            finally
            {
                fs.Close();
                Console.WriteLine("Dane zapisano prawidłowo");
            }

        }
        static void serializujGrafiki(Szpital szpital)
        {
            FileStream fs = new FileStream("SZPITAL1.dat", FileMode.Create);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, szpital.listaDyzurow);
            }
            catch (SerializationException e)
            {
                Console.WriteLine($"Nie udało się ponieważ {e.Message}");
                throw;
            }
            finally
            {
                fs.Close();
                Console.WriteLine("Dane zapisano prawidłowo");
            }

        }
        static void deserializuj(Szpital szpital)
        {
            if (!File.Exists("SZPITAL.dat")) Console.WriteLine("Nie udalo sie zlokalizowac pliku");
            else
            {
                Stream fs = File.OpenRead("SZPITAL.dat");
                if (fs.GetType() != szpital.listaDyzurow.GetType())
                {
                    fs.Close();
                    Console.WriteLine("Bledne typy danych");
                }
                else
                {
                    try
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        szpital.ListaPracownikow = (List<Czlowiek>)bf.Deserialize(fs);
                    }
                    catch (SerializationException e)
                    {
                        Console.WriteLine($"Nie udało się ponieważ {e.Message}");
                        throw;
                    }
                    finally
                    {
                        fs.Close();
                        Console.WriteLine("Dane wczytano prawidłowo");
                    }
                }
            }
        }
        static void deserializujGrafiki(Szpital szpital)
        {
            if (!File.Exists("SZPITAL.dat")) Console.WriteLine("Nie udalo sie zlokalizowac pliku");
            else
            {
                Stream fs = File.OpenRead("SZPITAL1.dat");
                if (fs.GetType() != szpital.listaDyzurow.GetType())
                {
                    fs.Close();
                    Console.WriteLine("Bledne typy danych");
                }
                else
                {
                    try
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        szpital.listaDyzurow = (List<List<Czlowiek>>)bf.Deserialize(fs);
                    }
                    catch (SerializationException e)
                    {
                        Console.WriteLine($"Nie udało się ponieważ {e.Message}");
                        throw;
                    }
                    finally
                    {
                        fs.Close();
                        Console.WriteLine("Dane wczytano prawidłowo");
                    }
                }
            }
        }
        public static void WyswietlPliki()
        {
            string[] fileArray = Directory.GetFiles(@"C:\Users\Adrian\Downloads\testing-space-master (2)\testing-space-master\projekt_szpital\PanelSterowania\bin\Debug", "*.dat");
            for (int i = 0; i < fileArray.Length; i++)
            {
                Console.WriteLine(Path.GetFileName(fileArray[i]));
            }
        }
    }
}//class

