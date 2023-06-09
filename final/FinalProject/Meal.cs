using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Meal
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
      if (value == MealType.Main || value == MealType.Side_Dish)
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
    Side_Dish
  }

  /// <summary>
  /// Instantiate a Meal object, populate its data from the user input and return it
  /// </summary>
  public static Meal Create()
  {
    Meal meal = new Meal();
    meal._id = GetNextId();

    Utils.TextAnimation("Meal name: \n");
    meal._name = Console.ReadLine();

    Utils.TextAnimation("Meal type (main or side dish): \n");
    string type = Console.ReadLine();

    if (type == "main")
    {
      meal._type = MealType.Main;
    }
    else if (type == "side dish")
    {
      meal._type = MealType.Side_Dish;
    }
    else
    {
      Utils.TextAnimation("Type error\n");
    }

    // Add ingredients from Ingredients database or create new ingredients
    int quantity;
    Utils.TextAnimation("how many ingredients? ");
    quantity = int.Parse(Console.ReadLine());

    // ------ ADD CODE TO ADD INGREDIENTS -----

    meal._ingredientsID.Add(1);
    meal._ingredientsID.Add(2);
    meal._ingredientsID.Add(3);

    return meal;
  }

  /// <summary>
  /// Display the Meal in the format "(Type) Meal Name"
  /// </summary>
  public void Display()
  {
    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
    string mealName = textInfo.ToTitleCase(_name);
    string mealType = textInfo.ToTitleCase(_type.ToString());

    Utils.TextAnimation($"({mealType}) {mealName}\n");
  }

  public void DisplayIngredients(List<Ingredient> userIngredients)
  {

  }

  // public string Serialize()
  // {
  //   var options = new JsonSerializerOptions
  //   {
  //     // Add indentation to the json data
  //     WriteIndented = true
  //   };

  //   // Serialize the current Meal instance
  //   string jsonString = JsonSerializer.Serialize(this, options);
  //   Console.WriteLine($"MEAL JSON: \n {jsonString}");

  //   // Option 1: Write the data in a file (Currently, this overrides the file)
  //   // File.WriteAllText("meal.json", jsonString);

  //   // Option 2: Return the JSONString
  //   return jsonString;
  // }

  // public void Deserialize()
  // {
  //   // Read the data (Currently, this is only one Meal)
  //   string jsonString = File.ReadAllText("meal.json");

  //   var options = new JsonSerializerOptions();
  //   options.Converters.Add(new JsonStringEnumConverter());

  //   Meal deserializedMeal = JsonSerializer.Deserialize<Meal>(jsonString, options);

  //   Console.WriteLine($"DESERIALIZED MEAL: \n ${deserializedMeal.ToString()}");

  // }

  private static int GetNextId()
  {
    return ++_lastId;
  }
}