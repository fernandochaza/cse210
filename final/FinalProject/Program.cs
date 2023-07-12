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

    var mainMeals = mealsData.GenerateMainMealsDictionary();
    var sideDishes = mealsData.GenerateSideDishDictionary();

    plannerData.PlanMeal(mainMeals, sideDishes);

    int newId = userProfile.MealsData.GetNewMealId();
    Console.WriteLine($"NEW ID: {newId}");


    mealsData.DisplayMeals();
    mealsData.DisplayIngredients();

    plannerData.DisplayPlan(userProfile.MealsData.Meals);

    // Console.WriteLine("¨COntinue with serialization...");
    // Console.ReadLine();

    // userProfile.SaveUserData();
  }
}
