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
        Console.WriteLine($"{thirdNumber.Top}/{thirdNumber.Bottom}"); // 6/7

        // Verify that the setters works correctly
        firstNumber.Top =5;
        firstNumber.Bottom =10;

        Console.WriteLine($"{thirdNumber.Top}/{thirdNumber.Bottom}"); // 5/10


        // Test four different options
        Fraction test = new Fraction();
        Console.WriteLine(test.GetFractionString());
        Console.WriteLine(test.GetDecimalValue());

        test.Top = 5;
        Console.WriteLine(test.GetFractionString());
        Console.WriteLine(test.GetDecimalValue());

        test.Top = 3;
        test.Bottom = 4;
        Console.WriteLine(test.GetFractionString());
        Console.WriteLine(test.GetDecimalValue());

        test.Top = 1;
        test.Bottom = 3;
        Console.WriteLine(test.GetFractionString());
        Console.WriteLine(test.GetDecimalValue());
    }
}