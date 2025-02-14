using System;
using System.Collections.Generic;

// Klasa bazowa Osoba
public class Osoba
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Pesel { get; set; }

    public void SetFirstName(string imie) => Imie = imie;
    public void SetLastName(string nazwisko) => Nazwisko = nazwisko;
    public void SetPesel(string pesel) => Pesel = pesel;

    public int GetAge()
    {
        int rok = int.Parse(Pesel.Substring(0, 2));
        int wiek = (rok < 24) ? (2000 + rok) : (1900 + rok);
        return DateTime.Now.Year - wiek;
    }

    public string GetGender() => (int.Parse(Pesel[9].ToString()) % 2 == 0) ? "Kobieta" : "Mężczyzna";

    public virtual bool CanGoAloneToHome()
    {
        return false;
    }
}

// Klasa Uczen dziedzicząca po Osoba
public class Uczen : Osoba
{
    public string Szkola { get; set; }
    public bool MozeSamWracacDoDomu { get; set; }

    public void SetSchool(string szkola) => Szkola = szkola;
    public void ChangeSchool(string nowaSzkola) => Szkola = nowaSzkola;
    public void SetCanGoHomeAlone(bool canGo) => MozeSamWracacDoDomu = canGo;

    public override bool CanGoAloneToHome()
    {
        return GetAge() >= 12 || MozeSamWracacDoDomu;
    }
}

// Klasa Nauczyciel dziedzicząca po Uczen
public class Nauczyciel : Osoba
{
    public string TytulNaukowy { get; set; }
    public List<Uczen> PodwladniUczniowie { get; set; } = new List<Uczen>();

    public void WhichStudentCanGoHomeAlone()
    {
        Console.WriteLine("Uczniowie, którzy mogą wracać sami do domu:");
        foreach (var uczen in PodwladniUczniowie)
        {
            if (uczen.CanGoAloneToHome())
            {
                Console.WriteLine($"- {uczen.Imie} {uczen.Nazwisko}");
            }
        }
    }
}

// Program główny
class Program
{
    static void Main()
    {
        Uczen uczen1 = new Uczen { Imie = "Stefan", Nazwisko = "Żerom", Pesel = "09123212345", Szkola = "SP1", MozeSamWracacDoDomu = false };
        Uczen uczen2 = new Uczen { Imie = "Arkadiusz", Nazwisko = "Słowacki", Pesel = "08050667890", Szkola = "SP1", MozeSamWracacDoDomu = true };

        Nauczyciel nauczyciel = new Nauczyciel { Imie = "Marek", Nazwisko = "Bambicki", Pesel = "75010212345", TytulNaukowy = "mgr" };
        nauczyciel.PodwladniUczniowie.Add(uczen1);
        nauczyciel.PodwladniUczniowie.Add(uczen2);

        nauczyciel.WhichStudentCanGoHomeAlone();
    }
}

