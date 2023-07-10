using System.Text.Json;
using System.Text.Json.Serialization;

public class PlannedDay : ISerializable
{
  private DateTime _date;
  // private Meal _plannedMeal;  //This should be an ID referencing to a Meal
  private List<int> _MealsID = new List<int>();  //This should be an ID referencing to a Meal
  private bool _isCompleted;
  private bool _isSkipped;

  // Declare getters and setters to allow private members serialization
  // Use JsonPropertyName to define a key name for the Json file

  [JsonPropertyName("date")]
  public DateTime Date
  {
    get { return _date; }
    set { _date = value; }
  }

  [JsonPropertyName("meals-id")]
  public List<int> MealIDs
  {
    get { return _MealsID; }
    set { _MealsID = value; }
  }

  [JsonPropertyName("completed")]
  public bool IsCompleted
  {
    get { return _isCompleted; }
    set { _isCompleted = value; }
  }

  [JsonPropertyName("skipped")]
  public bool IsSkipped
  {
    get { return _isSkipped; }
    set { _isSkipped = value; }
  }

  public static PlannedDay Create()
  {
    PlannedDay plannedDay = new PlannedDay();

    int day = Utils.GetUserInt("Day: ");
    int month = Utils.GetUserInt("Month: ");
    int currentYear = DateTime.Today.Year;

    DateTime date = new DateTime(currentYear, month, day);

    int meal = 1;

    plannedDay._date = date;
    plannedDay._MealsID.Add(meal);
    plannedDay._isCompleted = false;
    plannedDay._isSkipped = false;
    
    return plannedDay;
  }

  // Declare getters and setters to allow private members serialization
  // Use JsonPropertyName to define a key name for the Json file

  public string Serialize()
  {
    var options = new JsonSerializerOptions
    {
      // Add indentation to the json data
      WriteIndented = true
    };

    // Serialize the current Planned Day instance
    string jsonString = JsonSerializer.Serialize(this, options);
    Console.WriteLine($"PLANNED DAY JSON: \n {jsonString}");

    // Option 1: Write the data in a file (Currently, this overrides the file)
    File.WriteAllText("planned-day.json", jsonString);

    // Option 2: Return the JSONString
    return jsonString;
  }

  public void Deserialize()
  {
    // Read the data (Currently, this is only one planned day)
    string jsonString = File.ReadAllText("planned-day.json");

    var options = new JsonSerializerOptions();
    options.Converters.Add(new JsonStringEnumConverter());

    PlannedDay deserializedPlannedDay = JsonSerializer.Deserialize<PlannedDay>(jsonString, options);

    // Option 1: Return the PlannedDay
    // Return deserializedPlannedDay;

    // Option 2: Pass the values to the current PlannedDay

  }
}