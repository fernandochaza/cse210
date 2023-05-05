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
                    journal._entries.Add(newEntry);
                    break;
            }
        } while (userChoice != "5");

    }
}