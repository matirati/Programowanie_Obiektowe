using System;
using System.Collections.Generic;
using System.IO;

// Klasa bazowa dla napojów
abstract class Napoj
{
    public string Nazwa { get; set; }
    public decimal Cena { get; set; }
    public int Ilosc { get; set; }

    public Napoj(string nazwa, decimal cena, int ilosc)
    {
        Nazwa = nazwa;
        Cena = cena;
        Ilosc = ilosc;
    }

    public abstract void Wyswietl();
}

// Konkretny typ napoju
class Kawa : Napoj
{
    public Kawa(string nazwa, decimal cena, int ilosc) : base(nazwa, cena, ilosc) { }
    public override void Wyswietl()
    {
        Console.WriteLine($"Kawa: {Nazwa}, Cena: {Cena} PLN, Ilosc: {Ilosc}");
    }
}

class Herbata : Napoj
{
    public Herbata(string nazwa, decimal cena, int ilosc) : base(nazwa, cena, ilosc) { }
    public override void Wyswietl()
    {
        Console.WriteLine($"Herbata: {Nazwa}, Cena: {Cena} PLN, Ilosc: {Ilosc}");
    }
}

class Sok : Napoj
{
    public Sok(string nazwa, decimal cena, int ilosc) : base(nazwa, cena, ilosc) { }
    public override void Wyswietl()
    {
        Console.WriteLine($"Sok: {Nazwa}, Cena: {Cena} PLN, Ilosc: {Ilosc}");
    }
}

// Klasa zarządzająca automatem
class Automat
{
    private List<Napoj> napoje = new List<Napoj>();
    private string plikNapoje = "napoje.txt";
    private string plikTransakcje = "transakcje.txt";

    public Automat()
    {
        WczytajNapoje();
    }

    public void WczytajNapoje()
    {
        if (File.Exists(plikNapoje))
        {
            foreach (var linia in File.ReadAllLines(plikNapoje))
            {
                var dane = linia.Split(',');
                if (dane[0] == "Kawa") napoje.Add(new Kawa(dane[1], decimal.Parse(dane[2]), int.Parse(dane[3])));
                else if (dane[0] == "Herbata") napoje.Add(new Herbata(dane[1], decimal.Parse(dane[2]), int.Parse(dane[3])));
                else if (dane[0] == "Sok") napoje.Add(new Sok(dane[1], decimal.Parse(dane[2]), int.Parse(dane[3])));
            }
        }
    }

    public void WyswietlNapoje()
    {
        Console.WriteLine("Dostępne napoje:");
        foreach (var napoj in napoje)
        {
            napoj.Wyswietl();
        }
    }

    public void KupNapoj(string nazwa, decimal wrzuconaKwota)
    {
        var napoj = napoje.Find(n => n.Nazwa == nazwa);
        if (napoj != null && napoj.Ilosc > 0 && wrzuconaKwota >= napoj.Cena)
        {
            napoj.Ilosc--;
            Console.WriteLine($"Wydano {napoj.Nazwa}. Reszta: {wrzuconaKwota - napoj.Cena} PLN");
            ZapiszTransakcje(napoj.Nazwa, napoj.Cena);
            ZapiszNapoje();
        }
        else
        {
            Console.WriteLine("Nie można dokonać zakupu!");
        }
    }

    private void ZapiszTransakcje(string nazwa, decimal cena)
    {
        File.AppendAllText(plikTransakcje, $"{DateTime.Now},{nazwa},{cena}\n");
    }

    private void ZapiszNapoje()
    {
        using (StreamWriter sw = new StreamWriter(plikNapoje))
        {
            foreach (var napoj in napoje)
            {
                sw.WriteLine($"{(napoj is Kawa ? "Kawa" : napoj is Herbata ? "Herbata" : "Sok")},{napoj.Nazwa},{napoj.Cena},{napoj.Ilosc}");
            }
        }
    }

    public void MenuAdmin()
    {
        Console.WriteLine("Menu administracyjne");
        Console.WriteLine("1. Dodaj napój");
        Console.WriteLine("2. Usuń napój");
        Console.WriteLine("3. Wyświetl transakcje");
        Console.WriteLine("4. Wyświetl dostępne napoje");
        Console.Write("Wybór: ");
        int opcja = int.Parse(Console.ReadLine());

        if (opcja == 1)
        {
            Console.Write("Podaj typ napoju (Kawa, Herbata, Sok): ");
            string typ = Console.ReadLine();
            Console.Write("Podaj nazwę napoju: ");
            string nazwa = Console.ReadLine();
            Console.Write("Podaj cenę: ");
            decimal cena = decimal.Parse(Console.ReadLine());
            Console.Write("Podaj ilość: ");
            int ilosc = int.Parse(Console.ReadLine());

            if (typ == "Kawa") napoje.Add(new Kawa(nazwa, cena, ilosc));
            else if (typ == "Herbata") napoje.Add(new Herbata(nazwa, cena, ilosc));
            else if (typ == "Sok") napoje.Add(new Sok(nazwa, cena, ilosc));
            else Console.WriteLine("Nieznany typ napoju!");

            ZapiszNapoje();
        }
        else if (opcja == 2)
        {
            Console.Write("Podaj nazwę napoju do usunięcia: ");
            string nazwa = Console.ReadLine();
            napoje.RemoveAll(n => n.Nazwa == nazwa);
            ZapiszNapoje();
            Console.WriteLine("Napój usunięty.");
        }
        else if (opcja == 3)
        {
            Console.WriteLine("Historia transakcji:");
            Console.WriteLine(File.ReadAllText(plikTransakcje));
        }
        else if (opcja == 4)
        {
            WyswietlNapoje();
        }
    }
}

class Program
{
    static void Main()
    {
        Automat automat = new Automat();
        while (true)
        {
            Console.WriteLine("1. Kup napój");
            Console.WriteLine("2. Menu administracyjne");
            Console.WriteLine("3. Wyjście");
            Console.Write("Wybór: ");
            int opcja = int.Parse(Console.ReadLine());

            if (opcja == 1)
            {
                automat.WyswietlNapoje();
                Console.Write("Podaj nazwę napoju: ");
                string nazwa = Console.ReadLine();
                Console.Write("Podaj wrzuconą kwotę: ");
                decimal kwota = decimal.Parse(Console.ReadLine());
                automat.KupNapoj(nazwa, kwota);
            }
            else if (opcja == 2)
            {
                automat.MenuAdmin();
            }
            else if (opcja == 3)
            {
                break;
            }
        }
    }
}
