using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// 
/// </summary>
public class Meal : ISerializable
{
  private int _id;
  private static int _lastId = 0;
  private string _name;
  private MealType _type;
  private List<int> _ingredientsID = new List<int>();

  public Meal()
  {

  }

  // Declare getters and setters to allow private members serialization
  // Use JsonPropertyName to define a key name for the Json file

  [JsonPropertyName("meal-id")]
  public int Id
  {
    get { return _id; }
    set { _id = value; }
  }

  [JsonPropertyName("meal-name")]
  public string Name
  {
    get { return _name; }
    set { _name = value; }
  }

  [JsonPropertyName("meal-type")]
  public MealType Type
  {
    get { return _type; }
    set
    {
      // Validate that the meal type is either Main or SideDish
      if (value == MealType.Main || value == MealType.SideDish)
        _type = value;
      else
        throw new ArgumentException("Invalid meal type.");
    }
  }

  [JsonPropertyName("meal-ingredients")]
  public List<int> IngredientsID
  {
    get { return _ingredientsID; }
    set { _ingredientsID = value; }
  }

  public enum MealType
  {
    Main,
    SideDish
  }

  /// <summary>
  /// Instantiate a Meal object, populate its data from the user input and return it
  /// </summary>
  public static Meal Create()
  {
    Meal meal = new Meal();
    meal._id = GetNextId();

    Utils.DisplayText("Meal name: ");
    meal._name = Console.ReadLine();

    Utils.DisplayText("Meal type (main or side dish): ");
    string type = Console.ReadLine();

    if (type == "main")
    {
      meal._type = MealType.Main;
    }
    else if (type == "side dish")
    {
      meal._type = MealType.SideDish;
    }
    else
    {
      Console.WriteLine("Type error");
    }

    // Add ingredients from Ingredients database or create new ingredients
    int quantity;
    Utils.DisplayText("how many ingredients? ");
    quantity = int.Parse(Console.ReadLine());

    // ------ ADD CODE TO ADD INGREDIENTS -----

    meal._ingredientsID.Add(1);
    meal._ingredientsID.Add(2);
    meal._ingredientsID.Add(3);

    return meal;
  }

  public void Display()
  {
    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
    string name = textInfo.ToTitleCase(_name);

    string ingredients = "";

    foreach (int ingredient in _ingredientsID)
    {
      ingredients += $"{ingredient.ToString()}, ";
    }

    ingredients = ingredients.Substring(0, ingredients.Length - 2);

    Console.WriteLine($"-> {name} ({_type}):");
    Console.WriteLine($"Ingredients: {ingredients}");
  }

  public string Serialize()
  {
    var options = new JsonSerializerOptions
    {
      // Add indentation to the json data
      WriteIndented = true
    };

    // Serialize the current Meal instance
    string jsonString = JsonSerializer.Serialize(this, options);
    Console.WriteLine($"MEAL JSON: \n {jsonString}");

    // Option 1: Write the data in a file (Currently, this overrides the file)
    // File.WriteAllText("meal.json", jsonString);

    // Option 2: Return the JSONString
    return jsonString;
  }

  public void Deserialize()
  {
    // Read the data (Currently, this is only one Meal)
    string jsonString = File.ReadAllText("meal.json");

    var options = new JsonSerializerOptions();
    options.Converters.Add(new JsonStringEnumConverter());

    Meal deserializedMeal = JsonSerializer.Deserialize<Meal>(jsonString, options);

    Console.WriteLine($"DESERIALIZED MEAL: \n ${deserializedMeal.ToString()}");

    // Option 1: Return the Ingredient
    // Return deserializedIngredient;

    // Option 2: Pass the values to the current Ingredient
    // _id = deserializedIngredient._id;
    // _name = deserializedIngredient._name;
    // _type = deserializedIngredient._type;
  }

  private static int GetNextId()
  {
    return ++_lastId;
  }

  // String for testing purposes
  public override string ToString()
  {
    string ingredients = "";

    // foreach (Ingredient ingredient in _ingredients)
    // {
    //   ingredients += $" {ingredient.Name}";
    // }
    return $"ID: {_id}, NAME: {_name}, TYPE: {_type}, INGREDIENTS: ({ingredients})";
  }
}