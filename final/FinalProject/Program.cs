using System;
using ConsoleTables;

class Program
{
  static void Main(string[] args)
  {
    Console.Clear();

    // Instantiate the user profile and load the database
    Profile userProfile = new Profile();
    userProfile.InitializeProgram();

    // Create references to the user data to simplify access
    MealManager mealsData = userProfile.MealsData;
    Planner plannerData = userProfile.PlannerData;

    // Instantiate the Menu and Display welcome
    Menu menu = new Menu();
    menu.DisplayWelcome();

    List<string> options = new List<string>();
    options.Add("Plan a meal");
    options.Add("Display plan");
    options.Add("Plan a meal");
    options.Add("Display plan");

    List<string> options2 = new List<string>();
    options2.Add("Plan a meal");
    options2.Add("Display plan");
    options2.Add("Plan a meal");
    options2.Add("Display plan");

    var table = new ConsoleTable(options.ToArray());

    table.AddRow(options2.ToArray());
    table.Write();


    // userProfile.SaveUserData();
  }
}


// ------ PENDING ------- //
// Add a message to inform keyboard usage
// Make Esc the default key to go back
// Arrow up and down navigation
// Validate month and date inputs