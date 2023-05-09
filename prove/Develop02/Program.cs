using System;

public class Program
{
    static void Main(string[] args)
    {

        string selectedOption;

        // Instantiate a new Journal
        Journal journal = new Journal();
        journal._name = "John";

        // Instantiate a new Menu
        Menu mainMenu = new Menu();

        // Display welcome message
        mainMenu.DisplayWelcome(journal._name);

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
                    string prompt = new Prompt().ReturnRandomPrompt();
                    Entry newEntry = new Entry(prompt);
                    journal._entries.Add(newEntry);
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveJournalToFile();
                    break;
                case "4":
                    journal.LoadJournalFromFile();
                    break;

            }
        } while (selectedOption != "5");

    }
}