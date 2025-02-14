using System;
using System.Collections.Generic;

// Klasa bazowa Shape
public class Shape
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }

    public virtual void Draw()
    {
        Console.WriteLine("Rysowanie kształtu...");
    }
}

// Klasa Rectangle dziedzicząca po Shape
public class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysowanie prostokąta.");
    }
}

// Klasa Triangle dziedzicząca po Shape
public class Triangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysowanie trójkąta.");
    }
}

// Klasa Circle dziedzicząca po Shape
public class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysowanie koła.");
    }
}

// Program główny
class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>
        {
            new Rectangle(),
            new Triangle(),
            new Circle()
        };

        foreach (var shape in shapes)
        {
            shape.Draw();
        }
    }
}

