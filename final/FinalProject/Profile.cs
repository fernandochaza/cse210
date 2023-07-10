using System.Text.Json;
using System.Text.Json.Serialization;

public class Profile
{
  private string _databaseFilename = "meal-planner-db.JSON";
  private MealManager _mealManagerData;
  private Planner _plannerData;

  public Profile() { }

  public Profile(MealManager mealManager, Planner planner) {
    _mealManagerData = mealManager;
    _plannerData = planner;
   }

  // Declare getters and setters to allow private members serialization
  // Use JsonPropertyName to define a key name for the Json file

  [JsonPropertyName("meals-data")]
  public MealManager MealsData
  {
    get { return _mealManagerData; }
    set { _mealManagerData = value; }
  }

  [JsonPropertyName("planner-data")]
  public Planner PlannerData
  {
    get { return _plannerData; }
    set { _plannerData = value; }
  }

  /// <summary>
  /// Check the existence of the database file. Create a new one if it doesn't exists
  /// </summary>
  public void InitializeProgram()
  {
    // If the database file doesn't exists, create one
    if (!File.Exists(_databaseFilename))
    {
      // Code to create a JSON file containing the user data

      Utils.DisplayText(
          $"(!) New database created in the main program folder ({_databaseFilename})\n\n"
      );
    }
    else
    {
      LoadUserData();
      Utils.DisplayText($"(!) Reading data from the existing database ({_databaseFilename})\n\n");
    }
  }

  public void SaveUserData()
  {
    var options = new JsonSerializerOptions
    {
      // Add indentation to the json data
      WriteIndented = true
    };

    // Serialize the current Profile instance
    string jsonString = JsonSerializer.Serialize(this, options);

    // Option 1: Write the data in a file (---THIS OVERRIDES THE FILE---)
    File.WriteAllText(_databaseFilename, jsonString);
  }

  /// <summary>
  /// Read the database JSON file to create and populate instances of MealManager and Planner
  /// </summary>
  public void LoadUserData()
  {
    // Read the file
    string jsonString = File.ReadAllText(_databaseFilename);

    // Convert the Enums to populate Enum member variables (MealType and IngredientType)
    var options = new JsonSerializerOptions();
    options.Converters.Add(new JsonStringEnumConverter());

    Profile deserializedDatabase = JsonSerializer.Deserialize<Profile>(jsonString, options);

    // Pass the data to the current instance
    _mealManagerData = deserializedDatabase._mealManagerData;
    _plannerData = deserializedDatabase._plannerData;
  }
}
