namespace LAB2
{
    internal class Osoba
    {
        //definiowanie pól
        private string firstName;
        private string lastName;
        private int age;

        //właściwości
        public string FirstName 
        {
            get { return firstName; }
            //set { lastName = value; }
            set
            {
                if (value.Length > 2) firstName = value;
                else Console.WriteLine("Imie musi posiadać co najmniej 2 znaki");
            }
        } 
        public string LastName
        {
            get { return lastName; }
            //set { firstName = value; }
            set
            {
                if (value.Length > 2) lastName = value;
                else Console.WriteLine("Nazwisko musi posiadać co najmniej 2 znaki");
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0) Console.WriteLine("Wiek nie może być liczbą ujemną");
                else age = value;
            }
        }

        //konstruktor
        public Osoba() { }

        public Osoba(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        //konstruktor kopiujący
        public Osoba(Osoba user)
        {
            firstName = user.firstName;
            lastName = user.lastName;
            age = user.age;
        }

        


        public void View()
        {
            Console.WriteLine($"Imie:\t{firstName}" +
                $"\tNazwisko:\t{lastName}" +
                $"\tWiek:\t{age}");
        }
    }
}
