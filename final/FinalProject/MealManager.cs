using System.Text.Json;
using System.Text.Json.Serialization;

public class MealManager
{
  private List<Ingredient> _userIngredients = new List<Ingredient>();
  private List<Meal> _userMeals = new List<Meal>();

  public void Create(Ingredient ingredient, Meal meal)
  {
    _userIngredients.Add(ingredient);
    _userMeals.Add(meal);
  }

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

  public Ingredient GetIngredient(int ingredientId)
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

  public List<string> ListMeals()
  {
    List<string> meals = new List<string>();
    foreach (Meal meal in _userMeals)
    {
      string stringMeal = $"({meal.Type}) {meal.Name}";
      meals.Add(stringMeal);
    }

    return meals;
  }

  public Dictionary<int, string> GetMealIdAndString()
  {
    Dictionary<int, string> meals = new Dictionary<int, string>();
    foreach (Meal meal in _userMeals)
    {
      int mealId = meal.Id;
      string stringMeal = $"({meal.Type}) {meal.Name}";
      meals[mealId] = stringMeal;
    }

    return meals;
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