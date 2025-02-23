﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPracownikow
{
    [Serializable]
    public class Lekarz : Czlowiek
    {
        public int PWZ { get; private set; }
        public string Specjalizacja { get; private set; }
        public int ileDyzurow = 0;
        public int dniPodRzad = 0;
        public List<DateTime> Dyzury = new List<DateTime>();
        public Lekarz(string imie, string nazwisko, int pesel, int pwz, string specjalizacja, bool isAdmin, string pswrd)
            : base(imie, nazwisko, pesel, isAdmin, pswrd)
        {
            this.PWZ = pwz;
            this.Specjalizacja = specjalizacja;
        }
        public override string PrzedstawSieDlaAdmina()
        {
            return $"{this.GetType().Name}:\n{base.PrzedstawSieDlaAdmina()} Specjalizacja: {this.Specjalizacja} \nPWZ: {this.PWZ} ";
        }

        public override string PrzedstawSieDlaInnych()
        {
            return $"{this.GetType().Name}: {base.PrzedstawSieDlaInnych()} \nSpecjalizacja: {this.Specjalizacja}.";
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
        public void EdytujDane(string imie, string nazwisko, int pesel, int pwz,string specjalizacja)
        {
            base.EdytujDane(imie, nazwisko, pesel);
            if (pwz != 0) this.PWZ = pwz;
            else if (specjalizacja != "") this.Specjalizacja = specjalizacja;
        }
        public void UsunDyzur(DateTime data)
        {
            for (int i = 0; i < Dyzury.Count(); i++)
            {
                if (data == Dyzury[i]) Dyzury.RemoveAt(i);
            }
        }
        public void DodajDyzur(DateTime data)
        {
            Dyzury.Add(data);
        }
    }
}
