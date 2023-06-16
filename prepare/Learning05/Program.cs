using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square();
        square.Color = "Yellow";
        square.Side = 5;

        double squareArea = square.GetArea();
        Console.WriteLine($"Square area: {squareArea}");

        Rectangle rectangle = new Rectangle();
        rectangle.Color = "Orange";
        rectangle.Length = 5;
        rectangle.Width = 6;

        double rectangleArea = rectangle.GetArea();
        Console.WriteLine($"Rectangle area: {rectangleArea}");
    }
}