using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a unique ingredient with its name and type
/// </summary>
public class Ingredient
{
  private int _id;
  private static int _lastId = 0;
  private string _name;
  private IngredientType _type;

  public Ingredient()
  {

  }

  // Declare getters and setters to allow private members serialization
  // Use JsonPropertyName to define a key name for the Json file

  [JsonPropertyName("ingredient-id")]
  public int Id
  {
    get { return _id; }
    set { _id = value; }
  }

  [JsonPropertyName("ingredient-name")]
  public string Name
  {
    get { return _name; }
    set { _name = value; }
  }

  [JsonPropertyName("ingredient-type")]
  public IngredientType Type
  {
    get { return _type; }
    set
    {
      // Validate that the ingredient type is either Main or Seasoning
      if (value == IngredientType.Main || value == IngredientType.Seasoning)
        _type = value;
      else
        throw new ArgumentException("Invalid ingredient type.");
    }
  }

  // Define custom ingredient types
  public enum IngredientType
  {
    Main,
    Seasoning
  }

  /// <summary>
  /// Instantiate a Ingredient, populate its data from the user input and return it
  /// </summary>
  public static Ingredient Create()
  {
    Ingredient ingredient = new Ingredient();
    ingredient._id = GetNextId();

    Utils.DisplayText("Ingredient name: ");
    ingredient._name = Console.ReadLine();

    Utils.DisplayText("Ingredient type (main or seasoning): ");
    string type = Console.ReadLine();

    if (type == "main")
    {
      ingredient._type = IngredientType.Main;
    }
    else if (type == "seasoning")
    {
      ingredient._type = IngredientType.Seasoning;
    }
    else
    {
      Console.WriteLine("Type error");
    }

    return ingredient;
  }

  /// <summary>
  /// Displays the ingredient in the format "Name (type)"
  /// </summary>
  public void Display()
  {
    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
    string name = textInfo.ToTitleCase(_name);
    Console.WriteLine($"{name} ({_type})");
  }

  // public string Serialize()
  // {
  //   var options = new JsonSerializerOptions
  //   {
  //     // Add indentation to the json data
  //     WriteIndented = true
  //   };

  //   // Serialize the current Ingredient instance
  //   string jsonString = JsonSerializer.Serialize(this, options);
  //   Console.WriteLine($"INGREDIENT JSON: \n {jsonString}");

  //   // Option 1: Write the data in a file (Currently, this overrides the file)
  //   // File.WriteAllText("ingredient.json", jsonString);

  //   // Option 2: Return the JSONString
  //   return jsonString;
  // }

  // public void Deserialize()
  // {
  //   // Read the data (Currently, this is only one Ingredient)
  //   string jsonString = File.ReadAllText("ingredient.json");

  //   var options = new JsonSerializerOptions();
  //   options.Converters.Add(new JsonStringEnumConverter());

  //   Ingredient deserializedIngredient = JsonSerializer.Deserialize<Ingredient>(jsonString, options);

  // }

  private static int GetNextId()
  {
    return ++_lastId;
  }
}