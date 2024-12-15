using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Circle : Shape
    {
        public Circle(double x, double y, double radius) :
            base (x, y, radius,radius)
        {
        }

        public override void Draw()
        {
            Console.WriteLine($"Rysujemy koło o środku S " +
                $"x = {X}, y= {Y} i promieniu r = {Width}. \n");
        }
    }
}
