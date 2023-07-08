using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a unique ingredient with its name and type
/// </summary>
public class Ingredient : ISerializable
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

  [JsonPropertyName("ingredient_id")]
  public int Id
  {
    get { return _id; }
    set { _id = value; }
  }

  [JsonPropertyName("ingredient_name")]
  public string Name
  {
    get { return _name; }
    set { _name = value; }
  }

  [JsonPropertyName("ingredient_type")]
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
  /// Constructor used when deserializing the object???
  /// </summary>
  /// <param name="id"></param>
  /// <param name="name"></param>
  /// <param name="type"></param>
  // public Ingredient(int id, string name, IngredientType type)
  // {
  //   _id = id;
  //   _lastId = id;
  //   _name = name;
  //   _type = type;
  // }

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

  public void Serialize()
  {
    var options = new JsonSerializerOptions
    {
      // Add indentation to the json data
      WriteIndented = true
    };

    // Serialize the current Ingredient instance
    string jsonString = JsonSerializer.Serialize(this, options);
    Console.WriteLine($"INGREDIENT JSON: \n {jsonString}");

    // Option 1: Write the data in a file (Currently, this overrides the file)
    // File.WriteAllText("ingredient.json", jsonString);

    // Option 2: Return the JSONString
    // return jsonString;
  }

  public void Deserialize()
  {
    // Read the data (Currently, this is only one Ingredient)
    string jsonString = File.ReadAllText("ingredient.json");

    var options = new JsonSerializerOptions();
    options.Converters.Add(new JsonStringEnumConverter());

    Ingredient deserializedIngredient = JsonSerializer.Deserialize<Ingredient>(jsonString, options);

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
    return $"ID: {_id}, NAME: {_name}, TYPE: {_type}";
  }
}