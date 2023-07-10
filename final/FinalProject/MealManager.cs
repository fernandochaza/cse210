using System.Text.Json;
using System.Text.Json.Serialization;

public class MealManager : ISerializable
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

  public string Serialize()
  {
    var options = new JsonSerializerOptions
    {
      // Add indentation to the json data
      WriteIndented = true
    };

    // Serialize the current MealManager instance
    string jsonString = JsonSerializer.Serialize(this, options);
    Console.WriteLine($"MEAL MANAGER JSON: \n {jsonString}");

    // Option 1: Write the data in a file (Currently, this overrides the file)
    File.WriteAllText("meal-manager.json", jsonString);

    // Option 2: Return the JSONString
    return jsonString;
  }

  public void Deserialize()
  {
    // Read the data (Currently, this is only one meal-manager)
    string jsonString = File.ReadAllText("meal-manager.json");

    var options = new JsonSerializerOptions();
    options.Converters.Add(new JsonStringEnumConverter());

    MealManager deserializedMealManager = JsonSerializer.Deserialize<MealManager>(jsonString, options);

    // Option 1: Return the MealManager
    // Return deserializedMealManager;

    // Option 2: Pass the values to the current MealManager
  }
}