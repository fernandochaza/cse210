using System;

class Program
{
  static void Main(string[] args)
  {
    // Instantiate the user profile and load the database
    Profile userProfile = new Profile();
    userProfile.InitializeProgram();

    // Create references to the data to simplify access
    MealManager mealsData = userProfile.MealsData;
    Planner plannerData = userProfile.PlannerData;

    // Instantiate the Menu and Display welcome
    Menu menu = new Menu();
    menu.DisplayWelcome();

    var userMeals = mealsData.GenerateMainMealsDictionary();
    var sideDishes = mealsData.GenerateSideDishDictionary();

    plannerData.PlanMeal(userMeals, sideDishes);


    // userProfile.SaveUserData();
  }
}


// ------ PENDING ------- //
// Add a message to inform keyboard usage
// Make Esc the default key to go back
// Arrow up and down navigation