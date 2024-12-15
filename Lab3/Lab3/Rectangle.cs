using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Rectangle : Shape
    {
        public Rectangle(double x, double y, double height, double width) : base(x, y, height, width)
        {
        }

        public override void Draw()
        {
          //base.Draw();
          Console.WriteLine($"Rysujemy prostokąt o współrzędnych x = {X} y = {Y} o długości {Width} i szerokości {Height}");
        }
    }
}
