using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    internal class Student2
    {
        //definiowanie pól
        private string firstName;
        private string lastName;
        private double[]? grades;
        private int grades_count;

        public Student2(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;  
        }
        public double SredniaOcen
        {
            get
            {
                if(grades==null) return 0;
                double sum = 0;
                for(int i = 0; i < grades_count; i++)
                {
                    sum += grades[i];
                }
                return sum/grades_count; //średnia
            }
        }
        public void AddGrade(double grade)
        {
            if (grade<2 || grade>5)
            {
                Console.WriteLine("Ocena musi byc z przedziału 2-5");
                return;
            }
            if (grades == null)
            {
                Console.WriteLine("Tablica nie może być pusta");
                return;
            }
            if (grades_count >= grades.Length)
            {
                Console.WriteLine("Nie można dodać więcej ocen. Tablica jest pełna");
                return;
            }
            grades[grades_count] = grade;
            grades_count++;
            Console.WriteLine($"Dodano ocenę: {grade:F1}. Aktualna średnia: {SredniaOcen:F2}");
        }   

    }
}
