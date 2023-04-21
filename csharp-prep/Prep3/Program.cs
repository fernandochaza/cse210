using System;

class Program
{
    static void Main(string[] args)
    {

        string result;
        int guessAttempt = 0;

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        
        do
        {
            guessAttempt = guessAttempt + 1;
            
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

        Console.WriteLine($"Attempts made: {guessAttempt}");

    }
}