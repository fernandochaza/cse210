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

        string currentScore = profile.GetTotalScore().ToString();
        Utils.DisplayText($"\n> Your current score is: {currentScore}\n");

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
                    Console.Clear();
                    //Display the possible Goal options
                    Profile.DisplayGoalTypes();

                    // Ask for the user choice.
                    int typeSelected = 0;
                    do
                    {
                        typeSelected = Utils.GetUserInt("Which type of goal would you like to create (1, 2 or 3)? ");
                    } while (typeSelected < 1 || typeSelected > 3);

                    Console.Clear();
                    // Instantiate a new goal type
                    Goal goal = Profile.CreateEmptyGoal(typeSelected);

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
                    if (profile.GetAvailableGoalsQuantity() == 0)
                    {
                        Utils.DisplayText("(!) There are not available Goals to complete.\n");
                        Utils.DisplayText("(!) Please, add new goals to track.\n");
                        Utils.MessageToContinueAndClear();
                        break;
                    }
                    profile.AddEvent();
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("\n(!) Please select a valid option: ");
                    break;
            }
        } while (selectedOption != "4");
    }
}