using System;
using ConsoleTables;

class Program
{
  static void Main(string[] args)
  {
    Console.Clear();

    // Hide the cursor
    Console.CursorVisible = false;

    // Instantiate the user profile and load the database
    Profile userProfile = new Profile();
    userProfile.InitializeProgram();

    // Create references to the user data to simplify access
    MealManager mealsData = userProfile.MealsData;
    Planner plannerData = userProfile.PlannerData;
    plannerData.SetMealManager(mealsData);

    // Instantiate the Menu and Display welcome
    Menu menu = new Menu();
    menu.DisplayWelcome();

    Utils.MessageToContinueAndClear();

    string prompt = "Select an Option:";
    var options = new List<string>();
    options.Add("Plan a meal");
    options.Add("Upcoming meals");
    options.Add("Meals Database");
    options.Add("Ingredients Database");
    options.Add("Exit");

    string selectedOption;

    do
    {
      Console.Clear();
      selectedOption = Utils.GetSelectedOption(prompt, options);

      switch (selectedOption)
      {
        case "Plan a meal":
          Console.Clear();
          plannerData.PlanMeal();
          break;

        case "Upcoming meals":
          string selectedPlannerOption;

          do
          {
            Console.Clear();

            plannerData.DisplayPlan();

            var plannerOptions = new List<string>();
            plannerOptions.Add("Change a plan");
            plannerOptions.Add("Go back");

            var table = plannerData.DisplayPlan();

            selectedPlannerOption = Utils.GetSelectedOption("", plannerOptions, table);

            if (selectedPlannerOption == "Change a plan")
            {
              Console.Clear();
              plannerData.DisplayPlan();
              plannerData.EditPlan();
            }

          } while (selectedPlannerOption == "Change a plan");

          break;

        case "Meals Database":
          mealsData.DisplayMeals();
          break;

        default:
          break;
      }
    } while (selectedOption != null);



    // DISPLAY PLAN
    // var mealsDict = mealsData.GenerateMealsDictionary();
    // plannerData.DisplayPlan(mealsDict);

    // userProfile.SaveUserData();
  }
}


// ------ PENDING ------- //
// Add a message to inform keyboard usage
// Make Esc the default key to go back
// Arrow up and down navigation
// Validate month and date inputs
// Check methods VISIBILITY (encapsulate)