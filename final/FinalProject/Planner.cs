using System.Text.Json;
using System.Text.Json.Serialization;
using ConsoleTables;

public class Planner
{
  private List<PlannedDay> _userPlan = new List<PlannedDay>();

  public Planner()
  {

  }

  // Declare getters and setters to allow private members serialization
  // Use JsonPropertyName to define a key name for the Json file

  [JsonPropertyName("user-plan")]
  public List<PlannedDay> Meal
  {
    get { return _userPlan; }
    set { _userPlan = value; }
  }

  public void AddDay(PlannedDay plannedDay)
  {
    _userPlan.Add(plannedDay);
  }

  public void DisplayPlan(List<Meal> userMeals)
  {
    List<string> headers = new List<string>();
    headers.Add("Date");
    headers.Add("Meal");
    headers.Add("Side Dish");

    var table = new ConsoleTable(headers.ToArray());

    List<List<string>> data = GetPlannedDaysForTable(userMeals);

    foreach (List<string> row in data)
    {
      table.AddRow(row.ToArray());
    }

    table.Write(Format.Minimal);
  }

  public List<List<string>> GetPlannedDaysForTable(List<Meal> userMeals)
  {
    List<List<String>> data = new List<List<string>>();

    // int index = 0;

    foreach (PlannedDay plannedDay in _userPlan)
    {
      List<string> dataRow = new List<string>();

      string date = plannedDay.Date.ToShortDateString();

      dataRow.Add(date);
      
      string meal = "";
      string sideDish = "";

      foreach (Meal mealToMatch in userMeals)
      {
        if (mealToMatch.Id == plannedDay.MealIDs[0])
        {
          meal = mealToMatch.Name;
        }

        if (plannedDay.includesSideDish())
        { 
          if (mealToMatch.Id == plannedDay.MealIDs[1])
          {
            sideDish = mealToMatch.Name;
            break;
          }
        }

      }
        dataRow.Add(meal);
        dataRow.Add(sideDish);
        data.Add(dataRow);
    }

    return data;
  }

  public void PlanMeal(Dictionary<int, string> userMeals, Dictionary<int, string> sideDishes)
  {
    PlannedDay plannedDay = new PlannedDay(userMeals, sideDishes);

    if (plannedDay.MealIDs.Count > 0)
    {
      _userPlan.Add(plannedDay);
    }
  }

  // public string Serialize()
  // {
  //   var options = new JsonSerializerOptions
  //   {
  //     // Add indentation to the json data
  //     WriteIndented = true
  //   };

  //   // Serialize the current Planner instance
  //   string jsonString = JsonSerializer.Serialize(this, options);
  //   Console.WriteLine($"PLANNER JSON: \n {jsonString}");

  //   // Option 1: Write the data in a file (Currently, this overrides the file)
  //   File.WriteAllText("planner.json", jsonString);

  //   // Option 2: Return the JSONString
  //   return jsonString;
  // }

  // public void Deserialize()
  // {
  //   // Read the data (Currently, this is only one planner)
  //   string jsonString = File.ReadAllText("planner.json");

  //   var options = new JsonSerializerOptions();
  //   options.Converters.Add(new JsonStringEnumConverter());

  //   Planner deserializedPlanner = JsonSerializer.Deserialize<Planner>(jsonString, options);

  //   // Option 1: Return the Planner
  //   // Return deserializedPlanner;

  //   // Option 2: Pass the values to the current Planner
  // }
}