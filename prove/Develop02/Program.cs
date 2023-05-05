using System;

public class Program
{
    static void Main(string[] args)
    {

        string userChoice;

        // Instantiate a new Journal
        Journal journal = new Journal();
        journal._name = "John";

        // Instantiate a new Menu
        Menu mainMenu = new Menu();
        mainMenu.ReturnHeader(journal._name);

        do
        {
            // Display the menu options
            mainMenu.DisplayOptions();

            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Entry newEntry = new Entry();
                    newEntry.CreateEntry();
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
        } while (userChoice != "5");

    }
}