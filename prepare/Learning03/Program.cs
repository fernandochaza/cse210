using System;

class Program
{
    static void Main(string[] args)
    {
        // Create 3 Function instances to verify that the constructors work correctly
        Fraction firstNumber = new Fraction();
        Fraction secondNumber = new Fraction(6);
        Fraction thirdNumber = new Fraction(6,7);

        // Verify that the getters works correctly
        Console.WriteLine($"{thirdNumber.GetTop()}/{thirdNumber.GetBottom()}"); // 6/7

        // Verify that the setters works correctly
        firstNumber.SetTop(5);
        firstNumber.SetBottom(10);

        Console.WriteLine($"{thirdNumber.GetTop()}/{thirdNumber.GetBottom()}"); // 5/10


        // Test four different options
        Fraction test1 = new Fraction();
        Console.WriteLine(test1.GetFractionString());
        Console.WriteLine(test1.GetDecimalValue());

        Fraction test2 = new Fraction(5);
        Console.WriteLine(test2.GetFractionString());
        Console.WriteLine(test2.GetDecimalValue());

        Fraction test3 = new Fraction(3,4);
        Console.WriteLine(test3.GetFractionString());
        Console.WriteLine(test3.GetDecimalValue());

        Fraction test4 = new Fraction(1,3);
        Console.WriteLine(test4.GetFractionString());
        Console.WriteLine(test4.GetDecimalValue());
    }
}