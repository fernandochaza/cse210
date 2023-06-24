using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        // Instantiate a new Menu
        Menu mainMenu = new Menu();

        // Instantiate an user Profile and set User Name
        Profile profile = new Profile();
        profile.UserName = "Fernando";

        // Initialize User Database
        profile.InitializeDatabase();

        // Display welcome message
        mainMenu.DisplayWelcome(profile.UserName);

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
                        Utils.DisplayGoalTypes();

                        // Get and validate user choice
                        int typeSelected = Utils.GetUserInt("Which type of goal would you like to create? ");

                        Goal goal = Utils.CreateGoalFromInt(typeSelected);
                        goal.Initialize();

                    break;
                case "2":

                    break;
                case "3":

                    break;
                case "4":

                    break;
                case "5":

                    break;
                case "6":

                    break;
                default:
                    Console.WriteLine("\n(!) Please select a valid option: ");
                    break;
            }
        } while (selectedOption != "6");
    }
}