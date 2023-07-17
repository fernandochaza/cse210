using System.Text.Json;
using System.Text.Json.Serialization;
using ConsoleTables;

public class Planner
{
  private List<PlannedDay> _userPlan = new List<PlannedDay>();
  private bool _planingCancelled = false;
  private MealManager _mealManager;

  [JsonConstructor]
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

  [JsonIgnore]
  public bool PlanningCancelled
  {
    get { return _planingCancelled; }
    set { _planingCancelled = value; }
  }

  public void SetMealManager(MealManager mealManager)
  {
    _mealManager = mealManager;
  }

  /// <summary>
  /// Display the next planned meals in a table format
  /// </summary>
  /// <param name="userMeals">A dictionary containing an updated list of the user Meals with the Meal Id and Meal Name</param>
  public ConsoleTable DisplayPlan()
  {
    var userMeals = _mealManager.GenerateMealsDictionary();

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

  public void EditPlan()
  {
    Console.WriteLine();

    // Display the cursor
    Console.CursorVisible = true;

    var userMeals = _mealManager.GenerateMainMealsDictionary();
    var userSideDishes = _mealManager.GenerateSideDishDictionary();

    int planToChangeId = Utils.GetUserInt("Please, enter the ID of the day you want to change and press Enter: ");

    for (int i = 0; i < _userPlan.Count; i++)
    {
      if (_userPlan[i].Id == planToChangeId)
      {
        _userPlan[i].Edit(userMeals, userSideDishes);
      }
    }

    OrderPlanByDate();
  }

  /// <summary>
  /// Generate a List of List<string> where the inner List<string> represents a planned day data in the format "[date, meal, side dish]"
  /// </summary>
  /// <param name="userMeals">A dictionary containing an updated list of the user Meals with the Meal Id and Meal Name </param>
  /// <returns>The current planner data</returns>
  private List<List<string>> GetPlannedDaysForTable(Dictionary<int, string> userMeals)
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

  public void PlanMeal()
  {
    var userMeals = _mealManager.GenerateMainMealsDictionary();
    var userSideDishes = _mealManager.GenerateSideDishDictionary();

    DisplayPlan();

    PlannedDay plannedDay = new PlannedDay(userMeals, userSideDishes);

    if (!plannedDay.IsPlanningCancelled)
    {
      _userPlan.Add(plannedDay);
    }
    else
    {
      PlanningCancelled = true;
    }

    OrderPlanByDate();
  }

  private void OrderPlanByDate()
  {
    var orderedPlan = new List<PlannedDay>();
    orderedPlan = _userPlan.OrderBy(plannedDay => plannedDay.Date).ToList();

    _userPlan = orderedPlan;

  }
}