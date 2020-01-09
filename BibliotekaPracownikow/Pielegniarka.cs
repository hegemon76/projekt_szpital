using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPracownikow
{
    [Serializable]
    public class Pielegniarka : Czlowiek
    {
        public int dniPodRzad = 0;
        public int ileDyzurow = 0;
        public List<DateTime> Dyzury = new List<DateTime>();
        public Pielegniarka(string imie, string nazwisko, int pesel, bool isAdmin, string pswrd)
            : base(imie, nazwisko, pesel, isAdmin, pswrd) { }
        public override string PrzedstawSieDlaInnych()
        {
            return $"{this.GetType().Name}: {base.PrzedstawSieDlaInnych()}";
        }

        public override string PrzedstawSieDlaAdmina()
        {
            return $"{this.GetType().Name}: {base.PrzedstawSieDlaAdmina()}";
        }
        public void WyswietlGrafik()
        {
            if (Dyzury.Count() == 0) Console.WriteLine("Brak ustalonego grafiku");
            else
            {
                foreach (var data in Dyzury)
                {
                    Console.Write($"{data.ToShortDateString()}, ");
                }
            }
        }
    }
}
