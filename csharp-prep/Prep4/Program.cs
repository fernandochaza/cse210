using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        int number = -1;
        List<int> numbers = new List<int>();
        List<int> positives = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished");

        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
            if (number > 0)
            {
                positives.Add(number);
            }
        }

        Console.WriteLine($"The sum is: {numbers.Sum()}");
        Console.WriteLine($"The average is: {numbers.Average()}");
        Console.WriteLine($"The largest number is: {numbers.Max()}");
        Console.WriteLine($"The smallest positive number is: {positives.Min()}");
        numbers.Sort();
        Console.WriteLine($"The sorted list is: {string.Join(", ", numbers)}");
    }
}