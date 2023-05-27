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
                    // Display all the scriptures from the user database
                    myScriptures.DisplayScriptures();

                    // Ask the user to choose a scripture and save its choice
                    Console.Write("\n> Select the number of scripture to memorize: ");
                    int choice = int.Parse(Console.ReadLine());

                    Console.Clear();

                    // Get the Scripture instance
                    Scripture userScripture = myScriptures.GetScripture(choice);

                    userScripture.RevealWords();

                    // Display the scripture and start the memorizing process
                    Console.WriteLine(userScripture.ToString());
                    Console.Write("\n> Press enter to hide random words ");
                    Console.ReadLine();
                    Console.Clear();

                    string finishMemorizer;
                    do
                    {
                        // Hide random words from the scripture text
                        userScripture.HideRandom();

                        // Display the scripture with the hidden words
                        Console.WriteLine(userScripture.Reference.ToString());
                        Console.WriteLine(userScripture.DisplayText());

                        Console.Write("\nPress enter to continue or type \"quit\" to come back to the main menu: ");
                        finishMemorizer = Console.ReadLine();

                        Console.Clear();
                    } while (userScripture.CountHidden() < userScripture.Text.Count() && finishMemorizer != "quit");
                    break;
            }
        } while (selectedOption != "4");
    }
}