using System;
using System.Data.SqlClient;

class Program
{
    static string connStr = "Server=DIABOŁ\\MSSQLSERVER1;Database=BazaPr;Trusted_Connection=True;";

    static void Main()
    {
        Console.WriteLine("1. Dodaj klienta\n2. Pokaż klientów\n3. Usuń klienta");
        string choice = Console.ReadLine();

        if (choice == "1") AddClient();
        else if (choice == "2") ShowClients();
        else if (choice == "3") DeleteClient();
    }

    static void AddClient()
    {
        Console.Write("Imię: "); string imie = Console.ReadLine();
        Console.Write("Nazwisko: "); string nazwisko = Console.ReadLine();
        Console.Write("Email: "); string email = Console.ReadLine();
        Console.Write("Telefon: "); string telefon = Console.ReadLine();

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO Klienci (Imie, Nazwisko, Email, Telefon) VALUES (@Imie, @Nazwisko, @Email, @Telefon)", conn);
            cmd.Parameters.AddWithValue("@Imie", imie);
            cmd.Parameters.AddWithValue("@Nazwisko", nazwisko);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Telefon", telefon);
            cmd.ExecuteNonQuery();
        }
        Console.WriteLine("Dodano!");
    }

    static void ShowClients()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM Klienci", conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                Console.WriteLine($"{reader["Id"]}: {reader["Imie"]} {reader["Nazwisko"]} - {reader["Email"]}");
        }
    }

    static void DeleteClient()
    {
        Console.Write("Podaj ID klienta do usunięcia: ");
        int id = int.Parse(Console.ReadLine());

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            var cmd = new SqlCommand("DELETE FROM Klienci WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
        Console.WriteLine("Usunięto!");
    }
}
