using System;

class Program
{
    static void Main(string[] args)
    {

        string keepPlaying = "yes";

        Random randomGenerator = new Random();
        int magicNumber = 0;
        
        while (keepPlaying == "yes")
        {
            bool win = false;
            int guessAttempt = 0;
            magicNumber = randomGenerator.Next(1, 101);

            do
            {

                guessAttempt = guessAttempt + 1;
                
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
                    win = true;
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"Attempts made: {guessAttempt}");
                }


            } while (win == false);

            Console.WriteLine("Do you want to play again? (yes/no)");
            keepPlaying = Console.ReadLine();
        }


    }
}