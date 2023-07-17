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

    // Display welcome
    Menu.DisplayWelcome();

    Utils.MessageToContinueAndClear();

    var mainOptions = new List<string>();
    mainOptions.Add("Plan a meal");
    mainOptions.Add("Edit my plan");
    mainOptions.Add("My Meals Database");
    mainOptions.Add("My Ingredients Database");
    mainOptions.Add("Exit");

    string selectedOption;

    do
    {
      Console.Clear();
      var planTableMain = plannerData.DisplayPlanTable();
      selectedOption = Menu.GetSelectedOption(prompt:"Select an Option:", options:mainOptions, displayTableBottom:planTableMain);

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

        case "Edit my plan":
          string selectedPlannerOption;

          do
          {
            Console.Clear();

            plannerData.DisplayPlanTable();

            var plannerOptions = new List<string>();
            plannerOptions.Add("Change a planned day");
            plannerOptions.Add("Remove a planned day");

            // I need to pass the Planner table to the GetSelectedOption Method
            // because the method cleans que console. Not the best practice but for
            // now is the faster solution to allow the user to see the plan above the options
            var planTable = plannerData.DisplayPlanTable();

            selectedPlannerOption = Menu.GetSelectedOption(prompt:"", options:plannerOptions, displayTableTop:planTable);

            if (selectedPlannerOption == "Change a planned day")
            {
              Console.Clear();

              plannerData.EditPlan();

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
            }
            else if (selectedPlannerOption == "Remove a planned day")
            {
              Console.Clear();

              plannerData.RemoveDay();
              userProfile.SaveUserData();
            }

          } while (selectedPlannerOption != null);

          break;

        case "My Meals Database":
          string selectedMealDatabaseOption;

          do
          {
            var mealDatabaseOptions = new List<string>();
            mealDatabaseOptions.Add("Main Meals");
            mealDatabaseOptions.Add("Side Dishes");

            selectedMealDatabaseOption = Menu.GetSelectedOption(prompt:"Select an Option", options:mealDatabaseOptions);

            if (selectedMealDatabaseOption == "Main Meals")
            {
              Console.Clear();
              mealsData.DisplayMainMealsList();
            }
            else if (selectedMealDatabaseOption == "Side Dishes")
            {
              Console.Clear();
              mealsData.DisplaySideDishesList();
            }

            Utils.MessageToContinueAndClear();
          } while (selectedMealDatabaseOption != null);

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