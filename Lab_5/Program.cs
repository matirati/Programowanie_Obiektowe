using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //Kalkulator.Start();
        ZarzadzanieZamowieniami.Start();
        //GraZGadywanieKolorow.Start();
    }
}
/*
// Zadanie 1: Kalkulator
enum Operacja { Dodawanie, Odejmowanie, Mnozenie, Dzielenie }

class Kalkulator
{
    private static List<double> historiaWynikow = new List<double>();

    public static void Start()
    {
        Console.WriteLine("Kalkulator - Wprowadź dwie liczby:");
        try
        {
            Console.Write("Liczba 1: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Liczba 2: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Operacja (Dodawanie, Odejmowanie, Mnozenie, Dzielenie): ");
            Operacja op = (Operacja)Enum.Parse(typeof(Operacja), Console.ReadLine(), true);

            double wynik = WykonajOperacje(a, b, op);
            historiaWynikow.Add(wynik);
            Console.WriteLine($"Wynik: {wynik}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Błąd: Niepoprawny format liczby.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Błąd: Dzielenie przez zero!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Błąd: {e.Message}");
        }
    }

    private static double WykonajOperacje(double a, double b, Operacja op)
    {
        return op switch
        {
            Operacja.Dodawanie => a + b,
            Operacja.Odejmowanie => a - b,
            Operacja.Mnozenie => a * b,
            Operacja.Dzielenie => a / b,
            _ => throw new ArgumentException("Nieznana operacja")
        };
    }
}
*/
// Zadanie 2: Zarządzanie zamówieniami
enum StatusZamowienia { Oczekujace, Przyjete, Zrealizowane, Anulowane }

class ZarzadzanieZamowieniami
{
    private static Dictionary<int, (List<string>, StatusZamowienia)> zamowienia = new Dictionary<int, (List<string>, StatusZamowienia)>();

    public static void Start()
    {
        zamowienia[1] = (new List<string> { "Laptop", "Mysz" }, StatusZamowienia.Oczekujace);
        zamowienia[2] = (new List<string> { "Telefon" }, StatusZamowienia.Przyjete);
        WyswietlZamowienia();
        ZmienStatus(1, StatusZamowienia.Zrealizowane);
    }

    public static void ZmienStatus(int numer, StatusZamowienia nowyStatus)
    {
        try
        {
            if (!zamowienia.ContainsKey(numer))
                throw new KeyNotFoundException("Nie znaleziono zamówienia.");
            if (zamowienia[numer].Item2 == nowyStatus)
                throw new ArgumentException("Zamówienie już ma ten status.");
            zamowienia[numer] = (zamowienia[numer].Item1, nowyStatus);
            Console.WriteLine($"Status zamówienia {numer} zmieniony na {nowyStatus}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Błąd: {e.Message}");
        }
    }

    public static void WyswietlZamowienia()
    {
        foreach (var z in zamowienia)
            Console.WriteLine($"Zamówienie {z.Key}: {string.Join(", ", z.Value.Item1)} - Status: {z.Value.Item2}");
    }
}
/*
// Zadanie 3: Gra w zgadywanie kolorów
enum Kolor { Czerwony, Niebieski, Zielony, Zolty, Fioletowy }

class GraZGadywanieKolorow
{
    public static void Start()
    {
        List<Kolor> kolory = new List<Kolor> { Kolor.Czerwony, Kolor.Niebieski, Kolor.Zielony, Kolor.Zolty, Kolor.Fioletowy };
        Random rand = new Random();
        Kolor wylosowanyKolor = kolory[rand.Next(kolory.Count)];

        Console.WriteLine("Zgadnij kolor (Czerwony, Niebieski, Zielony, Zolty, Fioletowy):");
        while (true)
        {
            try
            {
                Kolor zgadnietyKolor = (Kolor)Enum.Parse(typeof(Kolor), Console.ReadLine(), true);
                if (zgadnietyKolor == wylosowanyKolor)
                {
                    Console.WriteLine("Brawo! Zgadłeś!");
                    break;
                }
                else
                {
                    Console.WriteLine("Nie zgadłeś, spróbuj ponownie.");
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Niepoprawny kolor! Wybierz z podanych.");
            }
        }
    }
}
*/