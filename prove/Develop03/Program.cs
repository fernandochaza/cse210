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

        Hide hideWords = new Hide();

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
                    string finishMemorizer;

                    Console.WriteLine(userScripture.ToString());
                    Console.WriteLine("\n> Press enter to hide random words");
                    Console.ReadLine();
                    Console.Clear();

                    do
                    {
                        userScripture.Text = hideWords.HideWords(userScripture.Text);
                        Console.WriteLine(userScripture.ToString());
                        Console.Write("\nPress enter to continue or type \"quit\" to come back to the main menu: ");
                        finishMemorizer = Console.ReadLine();
                        Console.Clear();

                    } while (hideWords.ExcludedQuantity < userScripture.Text.Count && finishMemorizer != "quit");
                    break;
            }
        } while (selectedOption != "4");

    }
}