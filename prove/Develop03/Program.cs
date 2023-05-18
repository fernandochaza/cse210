using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        // Instantiate a new Scriptures database
        MyScriptures myScriptures = new MyScriptures();
        myScriptures.Initialize();

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

            // Read the user choice
            selectedOption = Console.ReadLine();

            // Handle each menu option
            switch (selectedOption)
            {
                case "1":
                    myScriptures.DisplayScriptures();
                    break;
                case "2":
                    Scripture newScripture = new Scripture();
                    myScriptures.AddScriptureToDatabase(newScripture);
                    break;
                case "3":
                    // Display all the scriptures in the database
                    myScriptures.DisplayScriptures();

                    // Ask the user to choose a scripture and save its choice
                    Console.Write("\n> Select the number of scripture to memorize: ");
                    int choice = int.Parse(Console.ReadLine());

                    // Clear the Console
                    Console.Clear();

                    Scripture userScripture = myScriptures.GetScripture(choice);
                    string endMemorizer;

                    Console.WriteLine(userScripture.Reference.ToString());
                    Console.WriteLine(userScripture.JoinedText);
                    Console.WriteLine("\n> Press enter to hide random words");
                    Console.ReadLine();
                    Console.Clear();

                    do
                    {
                        userScripture.MemorizeScripture();
                        Console.WriteLine(userScripture.JoinedText);
                        Console.Write("\nPress enter to continue or type \"quit\" to come back to the main menu: ");
                        endMemorizer = Console.ReadLine();
                        Console.Clear();

                    } while (userScripture.MemorizeManager.ExcludedQuantity < userScripture.Text.Count && endMemorizer != "quit");
                    break;
            }
        } while (selectedOption != "4");

    }
}