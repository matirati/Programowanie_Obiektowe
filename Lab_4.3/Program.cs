using System;
using System.Collections.Generic;

// Interfejs IOsoba
public interface IOsoba
{
    string Imie { get; set; }
    string Nazwisko { get; set; }
    string ZwrocPelnaNazwe();
}

// Klasa Osoba implementująca IOsoba
public class Osoba : IOsoba
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Pesel { get; set; }

    public string ZwrocPelnaNazwe() => $"{Imie} {Nazwisko}";
}

// Metoda rozszerzająca dla List<IOsoba>
public static class OsobaExtensions
{
    public static void WypiszOsoby(this List<IOsoba> osoby)
    {
        foreach (var osoba in osoby)
        {
            Console.WriteLine(osoba.ZwrocPelnaNazwe());
        }
    }

    public static void PosortujOsobyPoNazwisku(this List<IOsoba> osoby)
    {
        osoby.Sort((o1, o2) => o1.Nazwisko.CompareTo(o2.Nazwisko));
    }
}

// Interfejs IStudent rozszerzający IOsoba
public interface IStudent : IOsoba
{
    string Uczelnia { get; set; }
    string Kierunek { get; set; }
    int Rok { get; set; }
    int Semestr { get; set; }
    string WypiszPelnaNazweIUczelnie();
}

// Klasa Student implementująca IStudent
public class Student : IStudent
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Uczelnia { get; set; }
    public string Kierunek { get; set; }
    public int Rok { get; set; }
    public int Semestr { get; set; }

    public string ZwrocPelnaNazwe() => $"{Imie} {Nazwisko}";
    public virtual string WypiszPelnaNazweIUczelnie() => $"{Imie} {Nazwisko} - {Kierunek} {Rok} {Uczelnia}";
}

// Klasa StudentWSIiZ dziedzicząca po Student
public class StudentWSIiZ : Student
{
    public override string WypiszPelnaNazweIUczelnie() => base.WypiszPelnaNazweIUczelnie() + " WSIiZ";
}

// Program główny
class Program
{
    static void Main()
    {
        List<IOsoba> osoby = new List<IOsoba>
        {
            new Osoba { Imie = "Jan", Nazwisko = "Kowalski" },
            new Osoba { Imie = "Anna", Nazwisko = "Nowak" },
            new Student { Imie = "Piotr", Nazwisko = "Zieliński", Uczelnia = "WSIiZ", Kierunek = "Informatyka", Rok = 2022, Semestr = 3 },
            new StudentWSIiZ { Imie = "Ewa", Nazwisko = "Wiśniewska", Uczelnia = "WSIiZ", Kierunek = "Grafika", Rok = 2021, Semestr = 4 }
        };

        Console.WriteLine("Lista osób przed sortowaniem:");
        osoby.WypiszOsoby();

        osoby.PosortujOsobyPoNazwisku();

        Console.WriteLine("\nLista osób po sortowaniu:");
        osoby.WypiszOsoby();
    }
}


