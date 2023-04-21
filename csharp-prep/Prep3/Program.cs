using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your magic number? ");
        string getUserValue = Console.ReadLine();
        int magicNumber = int.Parse(getUserValue);

        Console.Write("What is your guess? ");
        string getGuessValue = Console.ReadLine();
        int guessValue = int.Parse(getGuessValue);

        if (guessValue > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else if (guessValue < magicNumber)
        {
            Console.WriteLine("Higher");
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }

    }
}