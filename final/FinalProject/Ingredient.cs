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
  private bool _ingredientCreationCanceled = false;


  public Ingredient()
  {

  }

  public Ingredient(int ingredientId)
  {
    Console.CursorVisible = true;
    Id = ingredientId;

    Utils.DisplayMessage("\nPlease. Enter the ingredient name: ");
    Name = Console.ReadLine();

    Utils.DisplayMessage("\nInsert the Ingredient type (main or seasoning): ");
    string type = Console.ReadLine();

    type = type.ToLower();

    if (type.Contains("main"))
    {
      Type = IngredientType.Main;
    }
    else if (type.Contains("seasoning"))
    {
      Type = IngredientType.Seasoning;
    }
    else
    {
      Utils.DisplayMessage("\n(!) Type error. Please, enter a valid type...\n\n", type: "warning", speed: 1);
      Utils.MessageToContinueAndClear();
      IsIngredientCreationCanceled = true;
      Console.CursorVisible = false;
      return;
    }
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
        throw new ArgumentException("Invalid ingredient type.\n");
    }
  }

  [JsonIgnore]
  public bool IsIngredientCreationCanceled
  {
    get { return _ingredientCreationCanceled; }
    set { _ingredientCreationCanceled = value; }
  }


  // Define custom ingredient types
  public enum IngredientType
  {
    Main,
    Seasoning
  }

  /// <summary>
  /// Displays the ingredient in the format "Name (type)"
  /// </summary>
  public void Display()
  {
    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
    string name = textInfo.ToTitleCase(_name);
    Utils.DisplayMessage($"{name} ({_type}) \n");
  }

  private static int GetNextId()
  {
    return ++_lastId;
  }
}