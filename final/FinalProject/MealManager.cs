public class MealManager
{
  private List<Meal> _userMeals = new List<Meal>();
  private List<Ingredient> _userIngredients = new List<Ingredient>();

  public void AddMeal(Meal meal)
  {
    _userMeals.Add(meal);
  }

  public void AddIngredient(Ingredient ingredient)
  {
    _userIngredients.Add(ingredient);
  }

  public void DisplayMeals()
  {
    foreach (Meal meal in _userMeals)
    {
      meal.Display();
    }
  }

    public void DisplayIngredients()
  {
    foreach (Ingredient ingredient in _userIngredients)
    {
      ingredient.Display();
    }
  }
}