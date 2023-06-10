using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        // Instantiate a new Menu
        Menu mainMenu = new Menu();

        // Display welcome message
        mainMenu.DisplayWelcome("Fernando");

        // Variable to store the user option choice
        string selectedOption;
        
        do
        {
            // Display the menu options
            mainMenu.DisplayOptions();

            Countdown countdown = new Countdown(0);

            // Read the user choice
            selectedOption = Console.ReadLine();

            // Handle each menu option
            switch (selectedOption)
            {
                case "1":
                BreathingActivity breathing = new BreathingActivity();
                breathing.DisplayWelcome();

                // Ask the user for the session duration
                breathing.SetDuration();
                Console.Clear();

                // Display a preparation message
                Console.WriteLine("Get ready...");
                Spinner spinner = new Spinner(5);
                spinner.Initialize(5);

                // Initialize the Breathing Activity
                Console.Clear();
                breathing.Initialize();

                // Display an ending message
                breathing.EndMessage();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                    default:
                    Console.WriteLine("\n(!) Please select a valid option: ");
                    break;
            }
        } while (selectedOption != "4");
    }
}