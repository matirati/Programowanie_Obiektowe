using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    internal class BankAccount
    {
        //definiowanie pól
        public decimal Saldo { get; private set; }
        public string Wlasciciel { get; set; }
        //konstruktor
        public BankAccount(string wlasciciel, decimal saldo)
        {
            Saldo = saldo;
            Wlasciciel = wlasciciel;
        }

    
        public void Wplata(decimal kwota)
        {
            if (kwota <= 0)
            {
                Console.WriteLine("Kwota do wpłaty nie może być ujemna");
                return;
            }
            Saldo += kwota;
            Console.WriteLine($"Wpłacono: {kwota:C}. Aktualny stan konta: {Saldo:C}.");

        }
        public void Wyplata(decimal kwota)
        {
            if (kwota <= 0)
            {
                Console.WriteLine("Kwota do wypłaty nie może być ujemna");
                return;
            }
            if (kwota > Saldo)
            {
                Console.WriteLine("Niewystarczająca ilość środków na koncie");
            }
            Saldo -= kwota;
            Console.WriteLine($"Wypłacono: {kwota:C}. Aktualny stan konta: {Saldo:C}.");

        }
        public void View()
        {
            Console.WriteLine($"Właściciel: {Wlasciciel}\t\t Saldo:\t{Saldo}");
        }
    }
}
