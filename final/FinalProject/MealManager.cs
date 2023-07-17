using System.Text.Json;
using System.Text.Json.Serialization;

public class MealManager
{
  private List<Ingredient> _ingredients = new List<Ingredient>();
  private List<Meal> _meals = new List<Meal>();

  // Declare getters and setters to allow private members serialization
  // Use JsonPropertyName to define a key name for the Json file

  [JsonPropertyName("user-ingredients")]
  public List<Ingredient> Ingredients
  {
    get { return _ingredients; }
    set { _ingredients = value; }
  }

  [JsonPropertyName("user-meals")]
  public List<Meal> Meals
  {
    get { return _meals; }
    set { _meals = value; }
  }

  public void AddMeal(Meal meal)
  {
    _meals.Add(meal);
  }

  public void AddIngredient(Ingredient ingredient)
  {
    _ingredients.Add(ingredient);
  }

  public void AddIngredient()
  {

  }

  public int GetNewIngredientId()
  {
    int newId = 1;
    
    foreach (Ingredient ingredient in _ingredients)
    {
      if (ingredient.Id > newId)
      {
        newId = ingredient.Id;
      } 
    }

    newId++;

    return newId;
  }

  public int GetNewMealId()
  {
    int newId = 1;

    foreach (Meal meal in _meals)
    {
      if (meal.Id > newId)
      {
        newId = meal.Id;
      } 
    }

    newId++;

    return newId;
  }

  /// <summary>
  /// Display a list of all the user Meal Names. Separating Main Meals from Side Dishes
  /// </summary>
  public void DisplayMeals()
  {
    List<Meal> mainMeals = GetMainMealsList();
    List<Meal> sideDishes = GetSideDishList();

    Utils.TextAnimation("Main Meals:\n");
    foreach (Meal meal in mainMeals)
    {
      meal.Display();
    }

    Utils.TextAnimation("Side Dishes:\n");
    foreach (Meal sideDish in sideDishes)
    {
      sideDish.Display();
    }
  }

  /// <summary>
  /// Display a list of the user Main Meal Names
  /// </summary>
  public void DisplayMainMeals()
  {
    List<Meal> mainMeals = GetMainMealsList();

    Utils.TextAnimation("Main Meals:\n");
    foreach (Meal meal in mainMeals)
    {
      meal.Display();
    }
  }

  /// <summary>
  /// Display a list of the user Side Dishes Names
  /// </summary>
  public void DisplaySideDishes()
  {
    List<Meal> sideDishes = GetSideDishList();

    Utils.TextAnimation("Side Dishes:\n");
    foreach (Meal sideDish in sideDishes)
    {
      sideDish.Display();
    }
  }

  /// <summary>
  /// Displays a list of all the user ingredients in the format "Name (type)"
  /// </summary>
  public void DisplayIngredients()
  {
    Console.WriteLine("\n");
    foreach (Ingredient ingredient in _ingredients)
    {
      ingredient.Display();
    }
  }

  /// <summary>
  /// Get an ingredient given its ingredient ID from the user database
  /// </summary>
  /// <param name="ingredientId">The ingredient ID from the database</param>
  /// <returns>Returns an Ingredient instance or NULL if the are no matching ID</returns>
  public Ingredient GetIngredientById(int ingredientId)
  {
    foreach (Ingredient ingredient in _ingredients)
    {
      if (ingredient.Id == ingredientId)
      {
        return ingredient;
      }
    }

    return null;
  }

  /// <summary>
  /// Get a Meal given its meal ID from the user database
  /// </summary>
  /// <param name="mealId">The meal ID from the database</param>
  /// <returns>Returns a Meal instance or NULL if the are no matching IDs</returns>
  public Meal GetMealById(int mealId)
  {
    foreach (Meal meal in _meals)
    {
      if (meal.Id == mealId)
      {
        return meal;
      }
    }

    return null;
  }

  private List<Meal> GetMainMealsList()
  {
    var mainMeals = new List<Meal>();

    mainMeals = _meals.Where(meal => meal.Type == Meal.MealType.Main).ToList();

    return mainMeals;
  }

  private List<Meal> GetSideDishList()
  {
    var sideDishes = new List<Meal>();

    sideDishes = _meals.Where(meal => meal.Type == Meal.MealType.Side_Dish).ToList();

    return sideDishes;
  }

  /// <summary>
  /// Returns a List of string in the format "(Type) Meal Name" with all the meals in the user database
  /// </summary>
  /// <returns>A list of strings</returns>
  public List<string> GetMealsList()
  {
    List<string> meals = new List<string>();
    foreach (Meal meal in _meals)
    {
      string stringMeal = $"({meal.Type}) {meal.Name}";
      meals.Add(stringMeal);
    }

    return meals;
  }

  public Dictionary<int, string> GenerateMealsDictionary()
  {
    Dictionary<int, string> mealsDict = new Dictionary<int, string>();
    foreach (Meal meal in _meals)
    {
      int mealId = meal.Id;
      string stringMeal = $"{meal.Name}";
      mealsDict[mealId] = stringMeal;
    }

    return mealsDict;
  }

  public Dictionary<int, string> GenerateMainMealsDictionary()
  {
    Dictionary<int, string> mainMealsDict = new Dictionary<int, string>();
    foreach (Meal meal in _meals)
    {
      if (meal.Type == Meal.MealType.Main)
      {
        int mealId = meal.Id;
        mainMealsDict[mealId] = meal.Name;
      }
    }

    return mainMealsDict;
  }

  public Dictionary<int, string> GenerateSideDishDictionary()
  {
    Dictionary<int, string> sideDishDict = new Dictionary<int, string>();
    foreach (Meal meal in _meals)
    {
      if (meal.Type == Meal.MealType.Side_Dish)
      {
        int mealId = meal.Id;
        sideDishDict[mealId] = meal.Name;
      }
    }

    return sideDishDict;
  }
}