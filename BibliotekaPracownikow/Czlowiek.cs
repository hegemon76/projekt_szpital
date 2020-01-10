using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPracownikow
{
    [Serializable]
    public class Czlowiek
    {
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        public int Pesel { get; private set; }
        protected bool IsAdmin { get; private set; }
        //protected User DaneLogowania = new User();
        public Czlowiek(string imie, string nazwisko, int pesel, bool isAdmin, string password)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.Pesel = pesel;
            this.IsAdmin = isAdmin;

        }

        public Czlowiek(string imie, string nazwisko, bool isAdmin)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }

        public virtual string PrzedstawSieDlaAdmina()
        {
            return $"{this.Imie} {this.Nazwisko} \nPesel: {this.Pesel}";
        }

        public virtual string PrzedstawSieDlaInnych()
        {
            return $"{this.Imie} {this.Nazwisko}";
        }
        public virtual void EdytujDane(string imie, string nazwisko, int pesel)
        {
            if (imie != "") this.Imie = imie;
            if (nazwisko != "") this.Nazwisko = nazwisko;
            if (pesel != 0) this.Pesel = pesel;
        }
    }
}
