using System;

public class Program
{
    static void Main(string[] args)
    {
        string selectedOption;

        // Instantiate a new Journal
        Journal journal = new Journal();
        journal._name = "John";

        // If the Journal file doesn't exists, create one
        string journalData = "journal.txt";
        if (!File.Exists(journalData))
        {
            journal.SaveJournal();
        }
        else
        {
            journal.LoadJournal();
        }

        // Load the prompts manager
        PromptManager prompts = new PromptManager();

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
                    string prompt = prompts.ReturnRandomPrompt();
                    Entry newEntry = new Entry();
                    newEntry.AddEntry(prompt);
                    journal._entries.Add(newEntry);
                    journal.AddEntryToDatabase(newEntry);
                    break;
                case "2":
                    journal.DisplayJournal();
                    Console.Write("\nPress Enter to continue...");
                    Console.ReadLine();
                    break;
                case "3":
                    prompts.DisplayPrompts();
                    Console.Write("\nPress Enter to continue...");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Write("Enter the new prompt: ");
                    string newPrompt = Console.ReadLine();
                    prompts.AddPrompt(newPrompt);
                    break;
                case "5":
                    prompts.RemovePrompt();
                    break;
                case "6":
                    Console.WriteLine("See you soon!");
                    break;
            }
        } while (selectedOption != "6");
    }
}