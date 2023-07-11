using System;

class Program
{
  static void Main(string[] args)
  {
    // Instantiate the user profile and load the database
    Profile userProfile = new Profile();
    userProfile.InitializeProgram();

    // Instantiate the Menu and Display welcome
    Menu menu = new Menu();
    menu.DisplayWelcome();

    userProfile.PlannerData.PlanMeal(userProfile.MealsData.GetMealIdAndString(), userProfile.MealsData.Ingredients);
    

    // userProfile.MealsData.DisplayMeals();
    // userProfile.MealsData.DisplayIngredients();

    // userProfile.PlannerData.DisplayPlan(userProfile.MealsData.Meals);

    // Console.WriteLine("¨COntinue with serialization...");
    // Console.ReadLine();

    // userProfile.SaveUserData();
  }
}
