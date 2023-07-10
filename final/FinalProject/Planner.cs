using System.Text.Json;
using System.Text.Json.Serialization;

public class Planner : ISerializable
{
  private List<PlannedDay> _userPlan = new List<PlannedDay>();

  public Planner()
  {

  }

  public void AddDay(PlannedDay plannedDay)
  {
    _userPlan.Add(plannedDay);
  }

  // Declare getters and setters to allow private members serialization
  // Use JsonPropertyName to define a key name for the Json file

  [JsonPropertyName("user-plan")]
  public List<PlannedDay> Meal
  {
    get { return _userPlan; }
    set { _userPlan = value; }
  }

  public string Serialize()
  {
    var options = new JsonSerializerOptions
    {
      // Add indentation to the json data
      WriteIndented = true
    };

    // Serialize the current Planner instance
    string jsonString = JsonSerializer.Serialize(this, options);
    Console.WriteLine($"PLANNER JSON: \n {jsonString}");

    // Option 1: Write the data in a file (Currently, this overrides the file)
    File.WriteAllText("planner.json", jsonString);

    // Option 2: Return the JSONString
    return jsonString;
  }

  public void Deserialize()
  {
    // Read the data (Currently, this is only one planner)
    string jsonString = File.ReadAllText("planner.json");

    var options = new JsonSerializerOptions();
    options.Converters.Add(new JsonStringEnumConverter());

    Planner deserializedPlanner = JsonSerializer.Deserialize<Planner>(jsonString, options);

    // Option 1: Return the Planner
    // Return deserializedPlanner;

    // Option 2: Pass the values to the current Planner
  }
}