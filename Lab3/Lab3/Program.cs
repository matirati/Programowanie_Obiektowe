/*
class Zwierze
{
    public virtual void DajGlos()
    {
        Console.WriteLine("Zwierze wydaje dzwiek");
    }
}

class Pies : Zwierze
{
    public override void DajGlos()
    {
        Console.WriteLine("Pies wydaje dzwiek");
    }
}

class Kot : Zwierze
{
    public override void DajGlos()
    {
        Console.WriteLine("Kot wydaje dzwiek");
    }
}

class Program
{
    static void Main()
    {
        Zwierze zwierze = new Pies();
        Zwierze zwierze1 = new Kot();

        zwierze.DajGlos();
        zwierze1 .DajGlos();
    }
}
*/



/*
abstract class Figura
{
    public abstract double ObliczPole();

    public void Info()
    {
        Console.WriteLine("To jest figura geometryczna\n");
    }
}

class Kwadrat : Figura
{
    private double bok;

    public Kwadrat(double bok)
    {
        this.bok = bok;
    }

    public override double ObliczPole()
    {
        return bok * bok;
    }
}

class Program
{
    static void Main()
    {
      //Figura figura1 = new Figura();
        Figura figura = new Kwadrat(5);
        figura.Info();
        Console.WriteLine("Pole kwadratu: " + figura.ObliczPole());
    }
}
*/

/*
interface IZwierze
{
    void DajGlos();
}

class Pies : IZwierze
{
    public void DajGlos()
    {
        Console.WriteLine("Pies wydaje dzwiek");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IZwierze zwierze = new Pies();
        zwierze.DajGlos();
    }
}
*/

/*
 ** Zaimplementuj klasę Shape, posiadającą właściwości X, Y, Height, Width oraz virutalną metodę Draw.
Następnie zaimplementuj klasy:
• Rectangle,
• Triangle,
• Circle
które będą implementować metodę draw poprzez wypisanie na okno konsoli jaką figurę próbujemy
narysować. Następnie napisz program, który do listy List<Shape>, doda po obiekcie każdego typu z klas
dziedziczących. Następnie wywołaj dla każdego elementu w liście funkcję draw.


using ConsoleApp1;

List<Shape> shapes = new List<Shape>();

shapes.Add(new Rectangle(10, 20, 30, 40));
shapes.Add(new Triangle(15, 25, 35, 55));
shapes.Add(new Circle(5, 5, 10));

foreach (Shape shape in shapes)
    shape.Draw();

Console.ReadKey();
*/

/*
enum Kolor
{
    Czerwony, //indeks 0
    Zielony, //indeks 1
    Żółty, //indeks 2
    Niebieski = 10,
    Czarny, //indeks 11, przyjmuje kolejny po niebieskim
}

class Program
{
    static void Main(string[] args)
    {
        Kolor mojKolor = Kolor.Czerwony;
        Console.WriteLine("Wybrany kolor: " + mojKolor);
    }
}
*/


//łapywanie błędów poniżej


/*
try
{
    Console.WriteLine("Podaj licznik:");
    int licznik = int.Parse(Console.ReadLine());
    Console.WriteLine("Podaj mianownik:");
    int mianownik = int.Parse(Console.ReadLine());

    int wynik = licznik / mianownik;
    Console.WriteLine("Wynik dzielenia: " + wynik);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Błąd: Nie można dzielić przez zero");
    Console.WriteLine($"Szczegóły błedu: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine("Wystąpił błąd.");
    Console.WriteLine($"Szczegóły błędu: {ex.Message}");
}
finally
{
    Console.WriteLine("Wykonł się blok finally");
}

*/




class MojeWyjatki : Exception
{
    public MojeWyjatki(string message) : base(message)
    {

    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            SprawdzLiczbe(-23);
        }
        catch (MojeWyjatki ex)
        {
            Console.WriteLine($"Własny wyjątek: {ex.Message}");
        }
    }
    static void SprawdzLiczbe(int liczba)
    {
        if(liczba <= 0)
        {
            throw new MojeWyjatki("Liczba musi być większa od zera!");
        }
    }
}