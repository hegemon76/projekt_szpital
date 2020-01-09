using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPracownikow
{
    public class Administrator : Czlowiek
    {
        public Administrator(string imie, string nazwisko, int pesel, bool isAdmin, string pswrd)
            : base(imie, nazwisko, pesel, isAdmin,pswrd)
        {

        }
    }
}
