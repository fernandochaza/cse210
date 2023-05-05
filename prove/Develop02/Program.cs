using System;

public class Program
{
    static void Main(string[] args)
    {

        string userChoice;

        // Instantiate a new Journal
        Journal journal = new Journal();
        journal._name = "John";

        // Define a header
        string header = $"Hello {journal._name}! Welcome to your Journal Manager";

        // Create the menu options
        List<string> options = new List<string>();
        options.Add("Create a new entry");
        options.Add("Display my journal");
        options.Add("Save today's entries");
        options.Add("Load my journal");
        options.Add("Quit");

        // Instantiate a new Menu
        Menu mainMenu = new Menu(header, options);
        mainMenu.DisplayHeader();

        do
        {
            // Display the menu options
            mainMenu.DisplayOptions();

            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Entry newEntry = new Entry();
                    journal._entries.Add(newEntry);
                    break;
            }
        } while (userChoice != "5");

    }
}