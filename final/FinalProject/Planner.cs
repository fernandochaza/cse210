using System.Text.Json;
using System.Text.Json.Serialization;
using ConsoleTables;

public class Planner
{
  private List<PlannedDay> _userPlan = new List<PlannedDay>();

  public Planner() { }

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

  /// <summary>
  /// Display the next planned meals in a table format
  /// </summary>
  /// <param name="userMeals">A dictionary containing an updated list of the user Meals with the Meal Id and Meal Name</param>
  public ConsoleTable DisplayPlan(Dictionary<int, string> userMeals)
  {
    // Generate headers for the table
    var headers = new List<string>();
    headers.Add("Id");
    headers.Add("Date");
    headers.Add("Meal");
    headers.Add("Side Dish");
    var table = new ConsoleTable(headers.ToArray());

    // Get the current planner data as a List of List<string> where the inner List<string> represents a planned day
    List<List<string>> currentUserPlan = GetPlannedDaysForTable(userMeals);

    // Iterate over current user plan to add each planned day as a new table row
    foreach (List<string> plannedDay in currentUserPlan)
    {
      table.AddRow(plannedDay.ToArray());
    }

    // Display the table
    table.Write(Format.Minimal);

    return table;
  }

  public void EditPlan(Dictionary<int, string> userMeals, Dictionary<int, string> userSideDishes)
  {
    DisplayPlan(userMeals);
    Console.WriteLine();

    int planToChangeId = Utils.GetUserInt("Please, enter the ID of the day you want to change and press Enter: ");

    //ToDO: Extract this logic into a method in PLanneDay class ----!!

    for (int i = 0; i < _userPlan.Count; i++)
    {
      
      if (_userPlan[i].Id == planToChangeId)
      {
        _userPlan[i].Edit(userMeals, userSideDishes);
      }
    }
  }

  /// <summary>
  /// Generate a List of List<string> where the inner List<string> represents a planned day data in the format "[date, meal, side dish]"
  /// </summary>
  /// <param name="userMeals">A dictionary containing an updated list of the user Meals with the Meal Id and Meal Name </param>
  /// <returns>The current planner data</returns>
  public List<List<string>> GetPlannedDaysForTable(Dictionary<int, string> userMeals)
  {
    // Generate a variable to hold the planner data
    var plannedDays = new List<List<string>>();

    // Iterate over the current user plan
    foreach (PlannedDay plannedDay in _userPlan)
    {
      // Generate a variable to hold the planned day data
      var plannedDayAsList = new List<string>();

      string id = plannedDay.Id.ToString();
      string date = plannedDay.Date.ToShortDateString();
      string mealName = "";
      string sideDishName = "";

      // Get the meal id from the current iteration of a planned day
      int? mealId = plannedDay.MealIDs[0];

      // Try to get the meal name
      // ToDo: ERROR HANDLING
      userMeals.TryGetValue(mealId.Value, out mealName);

      if (plannedDay.includesSideDish())
      {
        // Get the Side Dish id from the current iteration of a planned day
        int? sideDishId = plannedDay.MealIDs[1];

        // Try to get the Side Dish name
        // ToDo: ERROR HANDLING
        userMeals.TryGetValue(sideDishId.Value, out sideDishName);
      }

      // Add the planned day data into the List of string
      plannedDayAsList.Add(id);
      plannedDayAsList.Add(date);
      plannedDayAsList.Add(mealName);
      plannedDayAsList.Add(sideDishName);

      // Add the List into the general plan List
      plannedDays.Add(plannedDayAsList);
    }

    return plannedDays;
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