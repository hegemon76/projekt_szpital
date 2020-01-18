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
            //Czlowiek czlowiek = new Lekarz("janek", "kowalski", 123, 3456, "kardiolog", false, "123");
            //Czlowiek czlowiek1 = new Lekarz("andrze", "kow", 123, 3456, "Kardiolog", false, "123");
            //Czlowiek czlowiek2 = new Lekarz("dimitr", "nowak", 123, 3456, "Kardiolog", false, "123");
            //Czlowiek czlowiek3 = new Lekarz("janusz", "luj", 123, 3456, "kardiolog", false, "123");
            //Czlowiek czlowiek4 = new Lekarz("milosz", "kamlot", 123, 3456, "laryngolog", false, "123");
            //Czlowiek czlowiek5 = new Lekarz("adam", "adamek", 123, 3456, "laryngolog", false, "123");
            //Czlowiek czlowiek6 = new Lekarz("eeeee", "eeeee", 123, 3456, "Neurolog", false, "123");
            //Czlowiek czlowiek7 = new Lekarz("ccccc", "acccdamek", 123, 3456, "Neurolog", false, "123");
            //Czlowiek czlowiek8 = new Pielegniarka("ddd", "ddd", 123, false, "123");
            //Czlowiek czlowiek9 = new Pielegniarka("ccc", "ccccc", 123, false, "123");
            //Czlowiek czlowiek10 = new Pielegniarka("bbbb", "bbbb", 123, false, "123");
            //Czlowiek czlowiek11 = new Pielegniarka("aaaa", "aaaa", 123, false, "123");
            //Czlowiek czlowiek12 = new Pielegniarka("muj", "kruj", 123, false, "123");
            //Czlowiek czlowiek13 = new Pielegniarka("kalinka", "malinka", 123, false, "123");
            //Czlowiek czlowiek14 = new Pielegniarka("janinka", "alinka", 123, false, "123");
            //szp.DodajPracownika(czlowiek);
            //szp.DodajPracownika(czlowiek1);
            //szp.DodajPracownika(czlowiek2);
            //szp.DodajPracownika(czlowiek3);
            //szp.DodajPracownika(czlowiek4);
            //szp.DodajPracownika(czlowiek5);
            //szp.DodajPracownika(czlowiek6);
            //szp.DodajPracownika(czlowiek7);
            //szp.DodajPracownika(czlowiek8);
            //szp.DodajPracownika(czlowiek9);
            //szp.DodajPracownika(czlowiek10);
            //szp.DodajPracownika(czlowiek11);
            //szp.DodajPracownika(czlowiek12);
            //szp.DodajPracownika(czlowiek13);
            //szp.DodajPracownika(czlowiek14);
            deserializujLudzi(szp);
            deserializujGrafiki(szp);
            menuWyboruUzytkownika(szp);
        }
        private const string specjalizacjaLekarza = "1.Kardiolog\n2.Urolog\n3.Neurolog\n4.Laryngolog";

        private const string menuGrafiku = "1.Ustal grafik dla wszystkich\n2.Wyswietl grafiki\n3.Usun duzyr\n4.Dodaj dyzur\n" +
             "5.Zapisz grafik\n6.Wczytaj grafik\n7.Cofnij";

        private const string menuWyboruKimJestes = "Wybierz uzytkownika:\n1.Administrator\n2.Uzytkownik\n3.Wyjscie";

        private const string menuOperacjiNaPracownikach = "1.Dodaj pracownika\n2.Usun pracownika\n" +
            "3.Edytuj dane pracownika\n4.Wyswietl pracownikow\n" +
            "5.Wyswietl grafik pracownika\n6.Zapisz liste pracownikow\n7.Wczytaj liste pracownikow\n8.Wyjscie";

        private const string menuAdmina = "1.Operacje na grafikach\n2.Operacje na pracownikach\n3.Cofnij";

        private const string menuUzytkownika = "1.Wyswietl dyzury dla wszystkich\n2.Wyswietl dyzury wskazanej osoby\n3.Cofnij";

        public static void MenuGlowneUzytkownika(Szpital szpital)
        {
            int wybor;
            do
            {
                wybor = podajLiczbe(menuUzytkownika, 1, 3);
                Console.Clear();
                switch (wybor)
                {
                    case 1:
                        szpital.WyswietlGrafik();
                        break;
                    case 2:
                        szpital.WyswietlPracownikow();
                        szpital.WyswietlGrafikDanegoPracownika(podajLiczbe("Ktora osobe wybierasz? ", 1, szpital.ListaPracownikow.Count()));
                        break;
                    default:
                        break;
                }
            } while (wybor != 3);
        }
        public static void MenuGlowneAdmina(Szpital szpital)
        {
            int wybor;
            do
            {
                wybor = podajLiczbe(menuAdmina, 1, 3);
                Console.Clear();
                switch (wybor)
                {
                    case 1:
                        OperacjeNaGrafiku(szpital);
                        break;
                    case 2:
                        OperacjeNaPracownikach(szpital);
                        break;
                    case 3:
                        serializujGrafiki(szpital);
                        serializujLudzi(szpital);
                        break;
                    default:
                        break;
                }
            } while (wybor != 3);
        }
        public static void menuWyboruUzytkownika(Szpital szpital)
        {
            int wybor;
            do
            {
                wybor = podajLiczbe(menuWyboruKimJestes, 1, 3);
                Console.Clear();
                switch (wybor)
                {
                    case 1:
                        MenuGlowneAdmina(szpital);
                        break;
                    case 2:
                        MenuGlowneUzytkownika(szpital);
                        break;
                    case 3:
                        serializujLudzi(szpital);
                        serializujGrafiki(szpital);
                        break;
                    default:
                        break;
                }
            } while (wybor != 3);
        }
        public static void OperacjeNaGrafiku(Szpital szpital)
        {
            int ileDniMaMiesiac = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            int wybor;
            do
            {
                wybor = podajLiczbe(menuGrafiku, 1, 7);
                Console.Clear();
                switch (wybor)
                {
                    case 1:
                        szpital.UstawGrafik();
                        break;
                    case 2:
                        szpital.WyswietlGrafik();
                        break;
                    case 3:
                        szpital.WyswietlGrafik();
                        int dzienMiesiaca = podajLiczbe("Podaj dzien miesiaca", 1, ileDniMaMiesiac);
                        int nrDyzuru = podajLiczbe("podaj nr dyzuru", 1, szpital.listaDyzurow[dzienMiesiaca - 1].Count());
                        szpital.UsunDyzur(dzienMiesiaca, nrDyzuru);
                        break;
                    case 4:
                        szpital.WyswietlPracownikow();
                        int nrPracownika = podajLiczbe("Podaj nr pracownika", 1, szpital.ListaPracownikow.Count());
                        int gdzieDodac = podajLiczbe("Podaj dzien do ktorego chcesz dodac pracownika", 1, ileDniMaMiesiac);
                        szpital.DodajDyzur(gdzieDodac, nrPracownika, ileDniMaMiesiac);
                        break;
                    case 5:
                        serializujGrafiki(szpital, podajTekst("Podaj nazwe grafiku: ", 2));
                        break;
                    case 6:
                        deserializujGrafiki(szpital, WybierzPlik());
                        break;
                    default:
                        break;
                }
            } while (wybor != 7);
        }
        public static void OperacjeNaPracownikach(Szpital szpital)
        {
            int wybor;
            do
            {
                wybor = podajLiczbe(menuOperacjiNaPracownikach, 1, 8);
                Console.Clear();
                switch (wybor)
                {
                    case 1:
                        szpital.DodajPracownika(UtworzPracownika());
                        break;
                    case 2:
                        szpital.WyswietlPracownikow();
                        szpital.UsunPracownika(podajLiczbe("Ktorego pracownika chcesz usunac?", 1, szpital.ListaPracownikow.Count()));
                        break;
                    case 3:
                        szpital.WyswietlPracownikow();
                        EdytujDane(szpital);
                        break;
                    case 4:
                        szpital.WyswietlPracownikowAdminowi();
                        break;
                    case 5:
                        szpital.WyswietlPracownikow();
                        szpital.WyswietlGrafikDanegoPracownika(podajLiczbe("Ktora osobe wybierasz? ", 1, szpital.ListaPracownikow.Count()));
                        break;
                    case 6:
                        serializujLudzi(szpital, podajTekst("Podaj nazwe grafiku: ", 2));
                        break;
                    case 7:
                        deserializujLudzi(szpital, WybierzPlik());
                        break;
                    default:
                        break;
                }
            } while (wybor != 8);
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
        static void serializujLudzi(Szpital szpital, string nazwaPliku)
        {
            nazwaPliku = nazwaPliku + ".dat";
            FileStream fs = new FileStream(nazwaPliku, FileMode.Create);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, szpital.ListaPracownikow);
            }
            catch (SerializationException e)
            {
                Console.WriteLine($"Nie udało się ponieważ {e.Message}");
            }
            finally
            {
                fs.Close();
                Console.WriteLine("Dane zapisano prawidłowo");
            }
        }
        static void serializujLudzi(Szpital szpital)
        {
            string nazwaPliku = "pracownicy.dat";
            FileStream fs = new FileStream(nazwaPliku, FileMode.Create);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, szpital.ListaPracownikow);
            }
            catch (SerializationException e)
            {
                Console.WriteLine($"Nie udało się ponieważ {e.Message}");
            }
            finally
            {
                fs.Close();
                Console.WriteLine("Dane zapisano prawidłowo");
            }
        }
        static void deserializujLudzi(Szpital szpital, string wybranyPlik)
        {
            if (!File.Exists(wybranyPlik)) Console.WriteLine("Nie udalo sie zlokalizowac pliku");
            else
            {
                Stream fs = File.OpenRead(wybranyPlik);
                BinaryFormatter bf = new BinaryFormatter();
                if (bf.Deserialize(fs) is List<Czlowiek>)
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    szpital.ListaPracownikow = (List<Czlowiek>)bf.Deserialize(fs);
                    fs.Close();
                    Console.WriteLine("Wczytano poprawnie");
                }
                else
                {
                    fs.Close();
                    Console.WriteLine("Bledny format wczyywanego pliku");
                }
            }
        }
        static void deserializujLudzi(Szpital szpital)
        {
            string wybranyPlik = "pracownicy.dat";
            if (!File.Exists(wybranyPlik)) Console.WriteLine("Nie udalo sie zlokalizowac pliku");
            else
            {
                Stream fs = File.OpenRead(wybranyPlik);
                BinaryFormatter bf = new BinaryFormatter();
                if (bf.Deserialize(fs) is List<Czlowiek>)
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    szpital.ListaPracownikow = (List<Czlowiek>)bf.Deserialize(fs);
                    fs.Close();
                    Console.WriteLine("Wczytano poprawnie");
                }
                else
                {
                    fs.Close();
                    Console.WriteLine("Bledny format wczyywanego pliku");
                }
            }
        }
        static void serializujGrafiki(Szpital szpital, string nazwaPliku)
        {
            nazwaPliku = nazwaPliku + ".dat";
            FileStream fs = new FileStream(nazwaPliku, FileMode.Create);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, szpital.listaDyzurow);
            }
            catch (SerializationException e)
            {
                Console.WriteLine($"Nie udało się ponieważ {e.Message}");
            }
            finally
            {
                fs.Close();
                Console.WriteLine("Dane zapisano prawidłowo");
            }
        }
        static void serializujGrafiki(Szpital szpital)
        {
            string nazwaPliku = "grafiki.dat";
            FileStream fs = new FileStream(nazwaPliku, FileMode.Create);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, szpital.listaDyzurow);
            }
            catch (SerializationException e)
            {
                Console.WriteLine($"Nie udało się ponieważ {e.Message}");
            }
            finally
            {
                fs.Close();
                Console.WriteLine("Dane zapisano prawidłowo");
            }
        }
        static void deserializujGrafiki(Szpital szpital, string wybranyPlik)
        {
            if (!File.Exists(wybranyPlik)) Console.WriteLine("Nie udalo sie zlokalizowac pliku");
            else
            {
                Stream fs = File.OpenRead(wybranyPlik);
                BinaryFormatter bf = new BinaryFormatter();
                if (bf.Deserialize(fs) is List<List<Czlowiek>>)
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    szpital.listaDyzurow = (List<List<Czlowiek>>)bf.Deserialize(fs);
                    fs.Close();
                    Console.WriteLine("Wczytano poprawnie");
                }
                else
                {
                    fs.Close();
                    Console.WriteLine("Bledny format wczyywanego pliku");
                }
            }
        }
        static void deserializujGrafiki(Szpital szpital)
        {
            string wybranyPlik = "grafiki.dat";
            if (!File.Exists(wybranyPlik)) Console.WriteLine("Nie udalo sie zlokalizowac pliku");
            else
            {
                Stream fs = File.OpenRead(wybranyPlik);
                BinaryFormatter bf = new BinaryFormatter();
                if (bf.Deserialize(fs) is List<List<Czlowiek>>)
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    szpital.listaDyzurow = (List<List<Czlowiek>>)bf.Deserialize(fs);
                    fs.Close();
                    Console.WriteLine("Wczytano poprawnie");
                }
                else
                {
                    fs.Close();
                    Console.WriteLine("Bledny format wczyywanego pliku");
                }
            }
        }
        public static string WybierzPlik()
        {
            int wybor;
            string plik;
            string[] fileArray = Directory.GetFiles(@"C:\Users\Adrian\Downloads\testing-space-master (2)\testing-space-master\projekt_szpital\PanelSterowania\bin\Debug", "*.dat");
            for (int i = 0; i < fileArray.Length; i++)
            {
                Console.WriteLine($"{i + 1}.{Path.GetFileName(fileArray[i])}");
            }
            wybor = podajLiczbe("Ktory plik wybierasz?", 0, fileArray.Length);

            plik = fileArray[wybor - 1];
            return plik;
        }
    }
}//class

