using System;

class Program
{
    static void Main(string[] args)
    {

        string result;

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);
        
        do
        {        
            Console.Write("What is your guess? ");
            string getGuessValue = Console.ReadLine();
            int guessValue = int.Parse(getGuessValue);

            if (guessValue > magicNumber)
            {
                result = "Lower";
            }
            else if (guessValue < magicNumber)
            {
                 result = "Higher";
            }
            else
            {
                result = "You guessed it!";
            }

            Console.WriteLine($"{result}");
        } while (result != "You guessed it!");

    }
}