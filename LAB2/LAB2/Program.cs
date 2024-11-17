
using LAB2;


/*obiekt klasy lub inaczej instancja klasy
Osoba osoba = new Osoba(); //Osoba na niebiesko to nasza klasa, osoba to może być user, Ala, Pies
osoba.FirstName = "Jan";
osoba.LastName = "Nowak";
osoba.Age = 20;
osoba.View();

Osoba osob1 = new Osoba("Janina","Kowalska", 23);
osob1.View();

//tablica obiektów
Osoba[] users =
{
    new Osoba("Jan","Nowak",23),
    new Osoba("Jan","Nowak",26),
    new Osoba("Jan","Nowak",29),
    new Osoba("Jan","Nowak",21),
    new Osoba("Jan","Nowak",18),
    new Osoba("Jan","Nowak",4),
    new Osoba("Jan","Nowak",2),
};

foreach(Osoba user in users) {
    user.View();
}


//wywołanie rozwiązania zadania 1
RunOsoba();

static void RunOsoba()
{
    Console.WriteLine("Podaj imie: ");
    string firstName = Console.ReadLine();

    Console.WriteLine("Podaj nazwisko: ");
    string lastName = Console.ReadLine();

    Console.WriteLine("Podaj wiek: ");
    int age = int.Parse(Console.ReadLine());

    //tworzenie biketu klasy Osoba
    Osoba osoba = new Osoba(firstName, lastName, age);
    osoba.View();
}

//wywołanie rozwiązania zadania 2
RunBankAccount();

static void RunBankAccount()
{
    BankAccount bankAccount = new BankAccount("Jan Nowak", 4500m);
    bankAccount.View();
    bankAccount.Wplata(500m);
    bankAccount.View();
    bankAccount.Wyplata(500000m);
}

//wywołanie rozwiązania student
RunStudent();
void RunStudent()
{
    Student student = new Student("Jan","Nowak","w69792");
    student.View();
    student.ViewStudent();
}*/

//wywołanie rozwiązana zadania 3
Zadanie3();
void Zadanie3()
{
    Student2 student = new Student2("Jan", "Nowak");
    student.AddGrade(4);
    student.AddGrade(5);
    student.AddGrade(3);
    student.AddGrade(4.5);
    student.AddGrade(4);
}

