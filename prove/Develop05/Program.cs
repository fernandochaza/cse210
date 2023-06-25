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
                    //Display the possible Goal options
                    Utils.DisplayGoalTypes();

                    // Ask for the user choice.
                    int typeSelected = Utils.GetUserInt("Which type of goal would you like to create? ");

                    // Instantiate a new goal type
                    Goal goal = Utils.InstantiateGoalFromInt(typeSelected);

                    // Populate the goal data from the user's inputs
                    goal.RequestGoalData();

                    // Add new goal to database and user profile
                    profile.AddGoalToDatabase(goal);

                    break;
                case "2":
                    // Display the current goals status
                    profile.DisplayGoalsData();
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