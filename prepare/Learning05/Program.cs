using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square();
        square.Color = "Yellow";
        square.Side = 5;

        double area = square.GetArea();
        Console.WriteLine($"Area: {area}");
    }
}