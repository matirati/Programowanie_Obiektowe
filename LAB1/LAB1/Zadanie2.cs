


using System.ComponentModel.Design;
using System.Numerics;

zadanie();

static void zadanie()
{
    menu();
}

static void menu()
{
ViewMenu:
    Console.WriteLine("---Kalkulator---");
    Console.WriteLine("1. Suma\n2. Różnica\n3. Iloczyn\n4. Iloraz\n5. Potęgowanie\n6. Funkcje trygonometryczne\n7. Wyjście");
    Console.WriteLine("Wybierz opcję: ");
    int choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1: Total(); break;
        case 2: Difference(); break;
        case 3: ProductNumber(); break;
        case 4: QuatationNumber(); break;
        //case 5: PotentationNumber(); break;
        //case 6: SquareNumber(); break;
        //case 7: Trigonometry(); break;
        case 8: Close(); break;
        default: Console.WriteLine("Błędny wybór, wybierz opcję jeszcze raz"); goto ViewMenu;
    }
}

//static void PotentationNumber()
//{
//    double a = DoubleInput();
//    double b = DoubleInput();
//    Console.WriteLine(
//}

static void QuatationNumber()
{
    double a = DoubleInput();
    double b = DoubleInput();
    Console.WriteLine(a / b);
}

static void ProductNumber()
{
    double a = DoubleInput();
    double b = DoubleInput();
    Console.WriteLine(a*b);
}

static void Difference()
{
    double a = DoubleInput();
    double b = DoubleInput();
    Console.WriteLine(a-b);
}

static void Total()
{
    double a = DoubleInput();
    double b = DoubleInput();
    Console.WriteLine(a + b);
}

static double DoubleInput()
{
    Console.Write("Podaj liczbę");
    double input = Convert.ToDouble(Console.ReadLine());
    return input;
}

static void Close()
{
    Console.WriteLine("Koniec programu");
    System.Environment.Exit(1);
}