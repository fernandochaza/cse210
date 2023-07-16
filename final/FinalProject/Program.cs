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
      selectedOption = Utils.GetSelectedString(prompt, options);

      switch (selectedOption)
      {
        case "Plan a meal":
          Console.Clear();

          var mealsDict = mealsData.GenerateMealsDictionary();
          var sideDishesDict = mealsData.GenerateMealsDictionary();
          plannerData.PlanMeal(mealsDict, sideDishesDict);
          break;

        case "Upcoming meals":
          int? selectedPlannerOption;

          do
          {
            Console.Clear();

            Dictionary<int, string> mealsDictForPlanner = mealsData.GenerateMealsDictionary();
            plannerData.DisplayPlan(mealsDictForPlanner);

            var plannerOptions = new List<string>();
            plannerOptions.Add("Change a plan");
            plannerOptions.Add("Go back");

            var table = plannerData.DisplayPlan(mealsDictForPlanner);

            selectedPlannerOption = Utils.GetSelectedIndexFromList("", plannerOptions, table);

            if (selectedPlannerOption == 0)
            {
              Console.Clear();
              Dictionary<int, string> mainMealsForPlanner = mealsData.GenerateMainMealsDictionary();
              Dictionary<int, string> sideDishesForPlanner = mealsData.GenerateSideDishDictionary();
              plannerData.DisplayPlan(mealsDictForPlanner);
              plannerData.EditPlan(mainMealsForPlanner, sideDishesForPlanner);
            }

          } while (selectedPlannerOption == 0);

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