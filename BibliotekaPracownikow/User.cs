using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPracownikow
{
    public class User
    {
        protected string Imie;
        protected string Username;
        protected string Password;

        public User(string imie, string username, string password)
        {
            Imie = imie;
            Username = username;
            Password = password;
        }
        public User()
        {

        }
    }
}
