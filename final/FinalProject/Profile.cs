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
  public void InitializeDatabase()
  {
    // If the database file doesn't exists, create one
    if (!File.Exists(_databaseFilename))
    {
      // Code to create a JSON file containing the user data

      Console.WriteLine(
          $"(!) New database created in the main program folder ({_databaseFilename})"
      );
    }
    else
    {
      // Code to load the existing data in the database file

      DeserializeUserData();
      Console.WriteLine($"(!) Reading data from the existing database ({_databaseFilename})");
    }
  }

  public void SerializeUserData()
  {
    var options = new JsonSerializerOptions
    {
      // Add indentation to the json data
      WriteIndented = true
    };

    // Serialize the current Profile instance
    string jsonString = JsonSerializer.Serialize(this, options);
    Console.WriteLine($"DATABASE JSON: \n {jsonString}");

    // Option 1: Write the data in a file (Currently, this overrides the file)
    File.WriteAllText(_databaseFilename, jsonString);

    // Option 2: Return the JSONString
  }

  public void DeserializeUserData()
  {
    // Read the data (Currently, this is only one planner)
    string jsonString = File.ReadAllText(_databaseFilename);

    var options = new JsonSerializerOptions();
    options.Converters.Add(new JsonStringEnumConverter());

    Profile deserializedDatabase = JsonSerializer.Deserialize<Profile>(jsonString, options);
    Console.WriteLine("DESERIALIZED DATABASE: \n{deserializedDatabase}");

    // Option 1: Return the Planner
    // Return deserializedPlanner;

    // Option 2: Pass the values to the current Planner
  }
}
