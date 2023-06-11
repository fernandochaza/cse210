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
                    breathing.InitializeActivity(breathing);

                    // Initialize the Breathing Activity
                    Console.Clear();
                    breathing.InitializeBreathing();

                    // Display an ending message
                    breathing.EndMessage(pauseSpinner);
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.InitializeActivity(reflection);

                    // Initialize the Reflection Activity
                    Console.Clear();
                    reflection.DisplayRandomPrompt();
                    reflection.DisplayQuestions();

                    // Display an ending message
                    reflection.EndMessage(pauseSpinner);

                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.InitializeActivity(listing);

                    // Initialize the Listing Activity
                    listing.InitializeListing();

                    // Display an ending message
                    listing.EndMessage(pauseSpinner);

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