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
    plannerData.SetIngredientsData(mealsData.Ingredients);

    // Use dependency injection for better data management
    plannerData.SetMealManager(mealsData);
    mealsData.SetPlanner(plannerData);

    foreach (Meal meal in mealsData.Meals)
    {
      meal.SetIngredientsData(mealsData.Ingredients);
    }

    foreach (PlannedDay plannedDay in plannerData.Plan)
    {
      plannedDay.SetMealsData(mealsData.Meals);
    }

    // Display welcome
    Menu.DisplayWelcome();

    Utils.MessageToContinueAndClear();

    var mainOptions = new List<string>();
    mainOptions.Add("Plan a meal");
    mainOptions.Add("Edit my plan\n");
    mainOptions.Add("My Meals Database");
    mainOptions.Add("Ingredients Database\n");
    mainOptions.Add("Generate Grocery List\n");
    mainOptions.Add("Exit");

    string selectedOption;

    do
    {
      Console.Clear();
      var planTableMain = plannerData.DisplayPlanTable();
      selectedOption = Menu.GetSelectedOption(prompt: "Select an Option:", options: mainOptions, displayTableBottom: planTableMain);

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

        case "Edit my plan\n":
          string selectedPlannerOption;

          do
          {
            Console.Clear();

            var plannerOptions = new List<string>();
            plannerOptions.Add("Change a planned day");
            plannerOptions.Add("Remove a planned day");
            plannerOptions.Add("Mark Completed");

            // I need to pass the Planner table to the GetSelectedOption Method
            // because the method cleans que console. Is not the best practice but for
            // now is the faster solution to allow the user to see the plan above the options
            var planTable = plannerData.DisplayPlanTable();

            selectedPlannerOption = Menu.GetSelectedOption(prompt: "", options: plannerOptions, displayTableTop: planTable);

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

              plannerData.RemovePlannedDay();
              userProfile.SaveUserData();
              Utils.DisplayMessage("\n(!) The selected planned day was successfully removed...\n", type: "info", speed: 1);
              Utils.MessageToContinueAndClear();
            }
            else if (selectedPlannerOption == "Mark Completed")
            {
              Console.Clear();

              plannerData.MarkPlanCompleted();
              userProfile.SaveUserData();
              Utils.MessageToContinueAndClear();
            }

          } while (selectedPlannerOption != null);

          break;

        case "My Meals Database":
          string selectedMealDatabaseOption;

          var mealDatabaseOptions = new List<string>();
          mealDatabaseOptions.Add("Add a new Meal");
          mealDatabaseOptions.Add("Remove a Meal \n");
          mealDatabaseOptions.Add("Main Meals List");
          mealDatabaseOptions.Add("Side Dishes List\n");
          mealDatabaseOptions.Add("Main Meal Ingredients");
          mealDatabaseOptions.Add("Side Dish Ingredients");

          do
          {
            selectedMealDatabaseOption = Menu.GetSelectedOption(prompt: "Select an Option: ", options: mealDatabaseOptions);

            if (selectedMealDatabaseOption == "Add a new Meal")
            {
              Console.Clear();
              mealsData.AddNewMeal();
              if (!mealsData.IsAddingCancelled)
              {
                userProfile.SaveUserData();
                Utils.DisplayMessage("\n\n(!) New Meal Added to the database...\n", type: "success", speed: 3);
                Utils.MessageToContinueAndClear();
              }
              else
              {
                // Reset default value
                mealsData.IsAddingCancelled = false;
              }
            }

            else if (selectedMealDatabaseOption == "Remove a Meal \n")
            {
              Console.Clear();
              mealsData.RemoveMeal();
              userProfile.SaveUserData();
              Utils.MessageToContinueAndClear();
            }

            else if (selectedMealDatabaseOption == "Main Meals List")
            {
              Console.Clear();
              mealsData.DisplayMainMealsList();

              Utils.MessageToContinueAndClear();
            }

            else if (selectedMealDatabaseOption == "Side Dishes List\n")
            {
              Console.Clear();
              mealsData.DisplaySideDishesList();

              Utils.MessageToContinueAndClear();
            }

            else if (selectedMealDatabaseOption == "Main Meal Ingredients")
            {
              Dictionary<int, string> mealsToCheck = mealsData.GenerateMainMealsDictionary();
              mealsData.VerifyMealIngredients(mealsToCheck);
              userProfile.SaveUserData();

            }

            else if (selectedMealDatabaseOption == "Side Dish Ingredients")
            {
              Dictionary<int, string> mealsToCheck = mealsData.GenerateSideDishDictionary();
              mealsData.VerifyMealIngredients(mealsToCheck);
              userProfile.SaveUserData();
            }

          } while (selectedMealDatabaseOption != null);

          break;

        case "Ingredients Database\n":
          string selectedIngredientDatabaseOption;

          var ingredientDatabaseOptions = new List<string>();
          ingredientDatabaseOptions.Add("Ingredients List");
          ingredientDatabaseOptions.Add("Add Ingredient");
          ingredientDatabaseOptions.Add("Remove Ingredient");

          do
          {
            selectedIngredientDatabaseOption = Menu.GetSelectedOption(prompt: "Select an Option: ", options: ingredientDatabaseOptions);

            if (selectedIngredientDatabaseOption == "Ingredients List")
            {
              mealsData.DisplayIngredientsTable();
              Console.WriteLine();
              Utils.MessageToContinueAndClear();
            }
            else if (selectedIngredientDatabaseOption == "Add Ingredient")
            {
              Console.Clear();
              mealsData.AddNewIngredient();
              if (!mealsData.IsAddingCancelled)
              {
                userProfile.SaveUserData();
                Utils.DisplayMessage("\n\n(!) New Ingredient added to the database...\n", type: "success", speed: 3);
                Utils.MessageToContinueAndClear();
              }
            }
            else if (selectedIngredientDatabaseOption == "Remove Ingredient")
            {
              Console.Clear();
              mealsData.RemoveIngredient();
              userProfile.SaveUserData();
              Utils.MessageToContinueAndClear();
            }
          } while (selectedIngredientDatabaseOption != null);

          break;

        case "Generate Grocery List\n":

          plannerData.GenerateGroceryList();
          Utils.MessageToContinueAndClear();

          break;

        case "Exit":
          return;

        default:
          break;
      }
    } while (selectedOption != null);
  }
}
