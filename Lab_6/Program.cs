using System;
using System.IO;
/* //Zadanie 1
class Program
{
    static void Main()
    {
        Console.Write("Podaj nazwę pliku: ");
        string fileName = Console.ReadLine();

        string albumNumber = "w69792"; // Tutaj wpisz swój numer albumu

        try
        {
            File.WriteAllText(fileName, albumNumber);
            Console.WriteLine($"Numer albumu zapisano do pliku: {fileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd: {ex.Message}");
        }
    }
}

//Zadanie 2
    using System;e
using System.IO;
//nazwa pliku testowego to text.txt
class Program
{
    static void Main()
    {
        Console.Write("Podaj nazwę pliku do odczytu: ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            try
            {
                string content = File.ReadAllText(fileName);
                Console.WriteLine("Zawartość pliku:");
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas odczytu pliku: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Plik nie istnieje.");
        }
    }
}

//Zadanie 3
using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string filePath = "pesels.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Plik pesels.txt nie istnieje.");
            return;
        }

        string[] peselList = File.ReadAllLines(filePath);
        int femaleCount = CountFemalePesels(peselList);

        Console.WriteLine($"Liczba żeńskich numerów PESEL: {femaleCount}");
    }

    static int CountFemalePesels(string[] peselList)
    {
        int count = 0;
        foreach (string pesel in peselList)
        {
            if (IsFemalePesel(pesel))
                count++;
        }
        return count;
    }

    static bool IsFemalePesel(string pesel)
    {
        if (pesel.Length != 11)
            return false;

        char genderDigit = pesel[9]; 
        return (genderDigit % 2 == 0); 
    }
}

//Zadanie 4
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, Dictionary<int, long>> populationData;

    static void Main()
    {
        string filePath = "db.json";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Plik db.json nie istnieje.");
            return;
        }

        string jsonString = File.ReadAllText(filePath);
        populationData = JsonSerializer.Deserialize<Dictionary<string, Dictionary<int, long>>>(jsonString);

        // Obliczanie różnicy populacji dla wybranych przypadków
        Console.WriteLine($"Różnica populacji Indii (1970-2000): {GetPopulationDifference("India", 1970, 2000)}");
        Console.WriteLine($"Różnica populacji USA (1965-2010): {GetPopulationDifference("USA", 1965, 2010)}");
        Console.WriteLine($"Różnica populacji Chin (1980-2018): {GetPopulationDifference("China", 1980, 2018)}");

        // Pobieranie danych od użytkownika
        Console.Write("Podaj kraj (USA, India, China): ");
        string country = Console.ReadLine();

        Console.Write("Podaj rok: ");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine($"Populacja {country} w {year} roku: {GetPopulation(country, year)}");

        // Różnica populacji dla przedziału lat
        Console.Write("Podaj rok początkowy: ");
        int startYear = int.Parse(Console.ReadLine());

        Console.Write("Podaj rok końcowy: ");
        int endYear = int.Parse(Console.ReadLine());

        Console.WriteLine($"Różnica populacji {country} ({startYear}-{endYear}): {GetPopulationDifference(country, startYear, endYear)}");

        // Obliczanie wzrostu populacji
        ShowPopulationGrowth();
    }

    static long GetPopulation(string country, int year)
    {
        if (populationData.ContainsKey(country) && populationData[country].ContainsKey(year))
        {
            return populationData[country][year];
        }
        return 0;
    }

    static long GetPopulationDifference(string country, int year1, int year2)
    {
        long pop1 = GetPopulation(country, year1);
        long pop2 = GetPopulation(country, year2);
        return pop1 > 0 && pop2 > 0 ? pop2 - pop1 : 0;
    }

    static void ShowPopulationGrowth()
    {
        Console.WriteLine("\nProcentowy wzrost populacji:");

        foreach (var country in populationData)
        {
            long previousPopulation = 0;

            foreach (var year in new SortedSet<int>(country.Value.Keys))
            {
                long currentPopulation = country.Value[year];

                if (previousPopulation > 0)
                {
                    double growth = ((double)(currentPopulation - previousPopulation) / previousPopulation) * 100;
                    Console.WriteLine($"{country.Key} {year}: {growth:F2}% wzrost");
                }

                previousPopulation = currentPopulation;
            }
        }
    }
}
*/
//Zadanie 5
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

record Person(int Id, string Name, int Age);

interface IPersonRepository
{
    void Add(Person person);
    List<Person> GetAll();
}

class FilePersonRepository : IPersonRepository
{
    private readonly string filePath;

    public FilePersonRepository(string filePath)
    {
        this.filePath = filePath;
        if (!File.Exists(filePath)) File.Create(filePath).Close();
    }

    public void Add(Person person)
    {
        File.AppendAllText(filePath, JsonSerializer.Serialize(person) + "\n");
    }

    public List<Person> GetAll()
    {
        return File.ReadAllLines(filePath)
                   .Select(line => JsonSerializer.Deserialize<Person>(line))
                   .Where(p => p != null).ToList();
    }
}

class Program
{
    static void Main()
    {
        var repo = new FilePersonRepository("people.json");

        repo.Add(new Person(1, "Alice", 30));
        repo.Add(new Person(2, "Bob", 25));

        foreach (var p in repo.GetAll())
            Console.WriteLine($"{p.Id}: {p.Name}, {p.Age} lat");
    }
}

