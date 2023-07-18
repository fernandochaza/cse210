using System.Text.Json;
using System.Text.Json.Serialization;
using ConsoleTables;

public class Planner
{
  private List<PlannedDay> _userPlan = new List<PlannedDay>();
  private bool _planingCancelled = false;
  private MealManager _mealManager;
  private List<Ingredient> _ingredientsData;

  [JsonConstructor]
  public Planner()
  {

  }

  // Declare getters and setters to allow private members serialization
  // Use JsonPropertyName to define a key name for the Json file

  [JsonPropertyName("user-plan")]
  public List<PlannedDay> Plan
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

  /// <summary>
  /// Set a MealManager instance to use dependency injection
  /// </summary>
  /// <param name="mealManager">The main MealManager Class instance containing the user data</param>
  public void SetMealManager(MealManager mealManager)
  {
    _mealManager = mealManager;
  }

  /// <summary>
  /// Set a List<Ingredient> instance to use dependency injection
  /// </summary>
  /// <param name="ingredients">A List<Ingredient> containing all the user Ingredients</param>
  public void SetIngredientsData(List<Ingredient> ingredients)
  {
    _ingredientsData = ingredients;
  }

  /// <summary>
  /// Display all the planned meals in a table format
  /// </summary>
  /// <param name="userMeals">A dictionary containing an updated list of the user Meals with the Meal Id and Meal Name</param>
  public ConsoleTable DisplayPlanTable()
  {
    var userMeals = _mealManager.GenerateMealsDictionary();

    // Generate headers for the table
    var headers = new List<string>();
    headers.Add("Id");
    headers.Add("Date");
    headers.Add("Main");
    headers.Add("Side Dish");
    headers.Add("Completed");
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

  /// <summary>
  /// Display only the uncompleted planned meals in a table format
  /// </summary>
  /// <param name="userMeals">A dictionary containing an updated list of the user Meals with the Meal Id and Meal Name</param>
  public ConsoleTable DisplayUncompletedPlansTable()
  {
    var userMeals = _mealManager.GenerateMealsDictionary();

    // Generate headers for the table
    var headers = new List<string>();
    headers.Add("Id");
    headers.Add("Date");
    headers.Add("Main");
    headers.Add("Side Dish");
    headers.Add("Completed");
    var table = new ConsoleTable(headers.ToArray());

    // Iterate over current user plan to add each planned day as a new table row
    foreach (PlannedDay plannedDay in _userPlan)
    {
      if (!plannedDay.IsCompleted)
      {
        List<string> plannedDayData = plannedDay.GetPlannedDayDataList();
        table.AddRow(plannedDayData.ToArray());
      }
    }

    // Display the table
    table.Write(Format.Minimal);

    return table;
  }


  public void EditPlan()
  {
    DisplayPlanTable();

    var userMeals = _mealManager.GenerateMainMealsDictionary();
    var userSideDishes = _mealManager.GenerateSideDishDictionary();

    // Display the cursor
    Console.CursorVisible = true;

    // ToDo: Verify the ID
    int planToChangeId = Utils.GetUserInt("Please, enter the ID of the day you want to change: ");

    PlannedDay plannedDayToEdit = _userPlan.Find(plannedDay => plannedDay.Id == planToChangeId);

    plannedDayToEdit.Edit(userMeals, userSideDishes);
    if (plannedDayToEdit.IsPlanningCancelled)
    {
      this.PlanningCancelled = true;

      // Reset to default
      plannedDayToEdit.IsPlanningCancelled = false;
    }

    OrderPlanByDate();
  }

  public void MarkPlanCompleted()
  {
    DisplayUncompletedPlansTable();
    // Display the cursor
    Console.CursorVisible = true;

    int? planToCompleteId = Utils.GetUserInt("\n> Please, enter the ID of the day you want to mark completed: ");

    for (int i = 0; i < _userPlan.Count; i++)
    {
      if (_userPlan[i].Id == planToCompleteId)
      {
        _userPlan[i].IsCompleted = true;
        Console.ForegroundColor = ConsoleColor.Red;
        Utils.TextAnimation($"\n(!) Congratulations for completing your {_userPlan[i].Date.ToShortDateString()} meal plan!\n");
        Console.ResetColor();
      }
    }
  }

  public void RemoveDay()
  {
    DisplayPlanTable();

    var userMeals = _mealManager.GenerateMainMealsDictionary();
    var userSideDishes = _mealManager.GenerateSideDishDictionary();

    // Display the cursor
    Console.CursorVisible = true;

    int? planToRemoveId = Utils.GetUserInt("Please, enter the ID of the day you want to remove: ");

    PlannedDay plannedDay = _userPlan.FirstOrDefault(day => day.Id == planToRemoveId);

    if (plannedDay != null)
    {
      _userPlan.Remove(plannedDay);
      Utils.TextAnimation("\n(!) The selected planned day was successfully removed...\n");
      plannedDay.DisplayPlannedDay(mainMealsDict: userMeals, sideDishesDict: userSideDishes);

      Utils.MessageToContinueAndClear();
    }
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
      string completed = plannedDay.IsCompleted ? "X": "";

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
      plannedDayAsList.Add(completed);

      // Add the List into the general plan List
      plannedDays.Add(plannedDayAsList);
    }

    return plannedDays;
  }

  public void PlanMeal()
  {
    var userMeals = _mealManager.GenerateMainMealsDictionary();
    var userSideDishes = _mealManager.GenerateSideDishDictionary();

    DisplayPlanTable();

    PlannedDay plannedDay = new PlannedDay(userMeals, userSideDishes);

    if (!plannedDay.IsPlanningCancelled)
    {
      plannedDay.Id = GetNewPlannedDayId();
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

  public int GetNewPlannedDayId()
  {
    int newId = 0;

    if (_userPlan.Count > 0)
    {
      newId = _userPlan.Max(plannedDay => plannedDay.Id) + 1;
    }
    else
    {
      newId = 1;
    }

    return newId;
  }

  public void GenerateGroceryList()
  {
    Console.Clear();
    Console.SetCursorPosition(0, 0);
    Console.ForegroundColor = ConsoleColor.Red;

    Utils.TextAnimation("Grocery List: \n");
    Console.ResetColor();

    var mealsList = new List<Meal>();
    foreach (PlannedDay plannedDay in _userPlan)
    {
      if (!plannedDay.IsCompleted)
      {
        foreach (int mealId in plannedDay.MealIDs)
        {
          Meal mealInstance = _mealManager.Meals.Find(meal => meal.Id == mealId);
          mealsList.Add(mealInstance);
        }
      }
    }

    var ingredientsList = new List<Ingredient>();
    foreach (Meal meal in mealsList)
    {
      foreach (int ingredientId in meal.IngredientsID)
      {
        Ingredient ingredientInstance = _ingredientsData.Find(ingredient => ingredient.Id == ingredientId);
        ingredientsList.Add(ingredientInstance);
      }
    }

    Console.ForegroundColor = ConsoleColor.Green;
    var groceryList = new List<string>();
    foreach (Ingredient ingredient in ingredientsList)
    {
      if (!groceryList.Contains(ingredient.Name))
      {
        groceryList.Add(ingredient.Name);
        Utils.TextAnimation($"\n{ingredient.Name}");
      }
    }
    Console.ResetColor();
  }
}