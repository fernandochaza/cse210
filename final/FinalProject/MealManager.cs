using System.Text.Json;
using System.Text.Json.Serialization;

public class MealManager
{
  private List<Ingredient> _userIngredients = new List<Ingredient>();
  private List<Meal> _userMeals = new List<Meal>();

  // public void Create(Ingredient ingredient, Meal meal)
  // {
  //   _userIngredients.Add(ingredient);
  //   _userMeals.Add(meal);
  // }

  // Declare getters and setters to allow private members serialization
  // Use JsonPropertyName to define a key name for the Json file

  [JsonPropertyName("user-ingredients")]
  public List<Ingredient> Ingredients
  {
    get { return _userIngredients; }
    set { _userIngredients = value; }
  }

  [JsonPropertyName("user-meals")]
  public List<Meal> Meals
  {
    get { return _userMeals; }
    set { _userMeals = value; }
  }

  public void AddMeal(Meal meal)
  {
    _userMeals.Add(meal);
  }

  public void AddIngredient(Ingredient ingredient)
  {
    _userIngredients.Add(ingredient);
  }

  /// <summary>
  /// Display a list of all the user Meals in the format "(Type) Meal Name"
  /// </summary>
  public void DisplayMeals()
  {
    Console.WriteLine("\n");
    foreach (Meal meal in _userMeals)
    {
      meal.Display();
    }
  }

  /// <summary>
  /// Displays a list of all the user ingredients in the format "Name (type)"
  /// </summary>
  public void DisplayIngredients()
  {
    Console.WriteLine("\n");
    foreach (Ingredient ingredient in _userIngredients)
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
    foreach (Ingredient ingredient in _userIngredients)
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
  public Meal GetMeal(int mealId)
  {
    foreach (Meal meal in _userMeals)
    {
      if (meal.Id == mealId)
      {
        return meal;
      }
    }

    return null;
  }

  /// <summary>
  /// Returns a List of string in the format "(Type) Meal Name" with all the meals in the user database
  /// </summary>
  /// <returns>A list of strings</returns>
  public List<string> GetMealsList()
  {
    List<string> meals = new List<string>();
    foreach (Meal meal in _userMeals)
    {
      string stringMeal = $"({meal.Type}) {meal.Name}";
      meals.Add(stringMeal);
    }

    return meals;
  }

  public Dictionary<int, string> GenerateMealsDictionary()
  {
    Dictionary<int, string> mealsDict = new Dictionary<int, string>();
    foreach (Meal meal in _userMeals)
    {
      int mealId = meal.Id;
      string stringMeal = $"({meal.Type}) {meal.Name}";
      mealsDict[mealId] = stringMeal;
    }

    return mealsDict;
  }

  public Dictionary<int, string> GenerateMainMealsDictionary()
  {
    Dictionary<int, string> mainMealsDict = new Dictionary<int, string>();
    foreach (Meal meal in _userMeals)
    {
      if (meal.Type == Meal.MealType.Main)
      {
        int mealId = meal.Id;
        string stringMeal = $"({meal.Type}) {meal.Name}";
        mainMealsDict[mealId] = stringMeal;
      }
    }

    return mainMealsDict;
  }

  public Dictionary<int, string> GenerateSideDishDictionary()
  {
    Dictionary<int, string> sideDishDict = new Dictionary<int, string>();
    foreach (Meal meal in _userMeals)
    {
      if (meal.Type == Meal.MealType.Side_Dish)
      {
        int mealId = meal.Id;
        string stringMeal = $"({meal.Type}) {meal.Name}";
        sideDishDict[mealId] = stringMeal;
      }
    }

    return sideDishDict;
  }

  // public string Serialize()
  // {
  //   var options = new JsonSerializerOptions
  //   {
  //     // Add indentation to the json data
  //     WriteIndented = true
  //   };

  //   // Serialize the current MealManager instance
  //   string jsonString = JsonSerializer.Serialize(this, options);
  //   Console.WriteLine($"MEAL MANAGER JSON: \n {jsonString}");

  //   // Option 1: Write the data in a file (Currently, this overrides the file)
  //   File.WriteAllText("meal-manager.json", jsonString);

  //   // Option 2: Return the JSONString
  //   return jsonString;
  // }

  // public void Deserialize()
  // {
  //   // Read the data (Currently, this is only one meal-manager)
  //   string jsonString = File.ReadAllText("meal-manager.json");

  //   var options = new JsonSerializerOptions();
  //   options.Converters.Add(new JsonStringEnumConverter());

  //   MealManager deserializedMealManager = JsonSerializer.Deserialize<MealManager>(jsonString, options);

  //   // Option 1: Return the MealManager
  //   // Return deserializedMealManager;

  //   // Option 2: Pass the values to the current MealManager
  // }
}