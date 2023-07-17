using System;
using ConsoleTables;

class Program
{
  static void Main(string[] args)
  {
    Console.Clear();

    // Hide the cursor for better experience
    Console.CursorVisible = false;

    // Instantiate the user profile and load the database
    Profile userProfile = new Profile();
    userProfile.InitializeProgram();

    // Create references to the user data to simplify access
    MealManager mealsData = userProfile.MealsData;
    Planner plannerData = userProfile.PlannerData;

    // Use dependency injection for better data management
    plannerData.SetMealManager(mealsData);

    // Instantiate the Menu and Display welcome
    Menu menu = new Menu();
    menu.DisplayWelcome();

    Utils.MessageToContinueAndClear();

    string prompt = "Select an Option:";
    var options = new List<string>();
    options.Add("Plan a meal");
    options.Add("Upcoming meals");
    options.Add("My Meals Database");
    options.Add("My Ingredients Database");
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

          if (!plannerData.PlanningCancelled)
          {
            userProfile.SaveUserData();
            Utils.MessageToContinueAndClear();
          }
          else
          {
            // Reset to default value
            plannerData.PlanningCancelled = false;
          }

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

            // I need to pass the Planner table to the GetSelectedOption Method
            // because the method cleans que console. Not the best practice but for
            // now is the faster solution to allow the user to see the plan above the options
            var table = plannerData.DisplayPlan();

            selectedPlannerOption = Utils.GetSelectedOption(prompt="", plannerOptions, table);

            if (selectedPlannerOption == "Change a plan")
            {
              Console.Clear();

              plannerData.DisplayPlan();
              plannerData.EditPlan();
              userProfile.SaveUserData();

              Utils.MessageToContinueAndClear();
            }

          } while (selectedPlannerOption == "Change a plan");

          break;

        case "My Meals Database":
          mealsData.DisplayMeals();

          Utils.MessageToContinueAndClear();
          break;

        case "Exit":
          return;

        default:
          break;
      }
    } while (selectedOption != null);



    // userProfile.SaveUserData();
  }
}


// ------ PENDING ------- //
// Add a message to inform keyboard usage
// Make Esc the default key to go back
// Arrow up and down navigation
// Validate month and date inputs
// Check methods VISIBILITY (encapsulate)