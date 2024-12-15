using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal class Triangle : Shape
    {
        public Triangle(double x, double y, double height, double width) : base(x, y, height, width)
        {
        }
        public override void Draw()
        {
            Console.WriteLine($"Rysujemy trójkąt o współrzędnych x = {X} y = {Y} o podstawie {Width} i wysokości {Height}");
        }
    }
}

