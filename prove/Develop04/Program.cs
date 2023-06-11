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

        // Set a global spinner animation
        Spinner pauseSpinner = new Spinner();

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
                    pauseSpinner.AnimationSeconds = 5;
                    pauseSpinner.Initialize();

                    // Initialize the Breathing Activity
                    Console.Clear();
                    breathing.Initialize();

                    // Display an ending message
                    breathing.EndMessage(pauseSpinner);
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.DisplayWelcome();

                    // Ask the user for the session duration
                    reflection.SetDuration();
                    Console.Clear();

                    // Display a preparation message
                    Console.WriteLine("Get ready...");
                    pauseSpinner.AnimationSeconds = 5;
                    pauseSpinner.Initialize();

                    // Initialize the Breathing Activity
                    Console.Clear();
                    reflection.DisplayRandomPrompt();
                    reflection.DisplayQuestions();

                    // Display an ending message
                    reflection.EndMessage(pauseSpinner);

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