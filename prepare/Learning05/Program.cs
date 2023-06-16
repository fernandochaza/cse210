using System;

class Program
{
    static void Main(string[] args)
    {
        // Testing Square
        Console.WriteLine("Testing classes methods");
        Square square = new Square();
        square.Color = "Yellow";
        square.Side = 5;

        double squareArea = square.GetArea();
        Console.WriteLine($"Square area: {squareArea}");


        // Testing Rectangle
        Rectangle rectangle = new Rectangle();
        rectangle.Color = "Orange";
        rectangle.Length = 5;
        rectangle.Width = 6;

        double rectangleArea = rectangle.GetArea();
        Console.WriteLine($"Rectangle area: {rectangleArea}");


        // Testing Circle
        Circle circle = new Circle();
        circle.Color = "Black";
        circle.Radius = 5;

        double circleArea = circle.GetArea();
        Console.WriteLine($"Circle area: {circleArea}");


        // Create list and test polymorphism
        Console.WriteLine("\nTesting polymorphism using a list");
        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            double area = shape.GetArea();
            Console.WriteLine($"Shape Color: {shape.Color}");
            Console.WriteLine($"Shape Area: {area}\n");
        }
    }
}