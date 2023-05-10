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

        // Load the prompt manager
        PromptManager prompts = new PromptManager();

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
                case "5":
                    prompts.DisplayPrompts();
                    break;
                case "6":
                    Console.Write("Enter the new prompt: ");
                    string newPrompt = Console.ReadLine();
                    prompts.AddPrompt(newPrompt);
                    break;
            }
        } while (selectedOption != "8");
    }
}