using System.Text.Json;
using System.Text.Json.Serialization;

public class PlannedDay
{
  private int _id;
  private DateTime _date;
  private List<int> _mealsID = new List<int>();
  private bool _isCompleted;

  private bool _planingCancelled = false;
  private List<Meal> _mealsData;

  [JsonConstructor]
  public PlannedDay()
  {
  }

  /// <summary>
  /// Instantiate a new PlannedDay from the user input
  /// </summary>
  /// <param name="mainMealsDict">Dictionary containing the Main meals ID and Name</param>
  /// <param name="sideDishesDict">Dictionary containing the Side Dishes ID and Name</param>
  public PlannedDay(Dictionary<int, string> mainMealsDict, Dictionary<int, string> sideDishesDict)
  {
    DateTime? date = Utils.GetDate();
    if (date == null)
    {
      IsPlanningCancelled = true;
      return;
    }

    List<string> options = new List<string>();
    options.Add("Yes");
    options.Add("No");

    Console.Clear();
    string includeSideDish = Menu.GetSelectedOption(prompt: "Do you want to include a Side Dish?", options);

    if (includeSideDish == null)
    {
      IsPlanningCancelled = true;
      return;
    }

    int? selectedMealId = Utils.GetSelectedKeyFromDict(prompt: "Select a meal: ", idAndNameDict: mainMealsDict);

    if (selectedMealId == null)
    {
      IsPlanningCancelled = true;
      return;
    }

    _mealsID.Add(selectedMealId.Value);

    if (includeSideDish == "Yes")
    {
      int? selectedSideDishId = Utils.GetSelectedKeyFromDict(prompt: "Select a Side Dish: ", idAndNameDict: sideDishesDict);
      if (selectedSideDishId == null)
      {
        IsPlanningCancelled = true;
        return;
      }
      _mealsID.Add(selectedSideDishId.Value);
    }

    _date = date.Value;
    _isCompleted = false;

    Utils.DisplayMessage("\n(!) Meal successfully planned!\n");
  }

  // Declare getters and setters to allow private members serialization
  // Use JsonPropertyName to define a key name for the Json file

  [JsonPropertyName("planned-day-id")]
  public int Id
  {
    get { return _id; }
    set { _id = value; }
  }

  [JsonPropertyName("date")]
  public DateTime Date
  {
    get { return _date; }
    set { _date = value; }
  }

  [JsonPropertyName("meals-id")]
  public List<int> MealIDs
  {
    get { return _mealsID; }
    set { _mealsID = value; }
  }

  [JsonPropertyName("completed")]
  public bool IsCompleted
  {
    get { return _isCompleted; }
    set { _isCompleted = value; }
  }

  [JsonIgnore]
  public bool IsPlanningCancelled
  {
    get { return _planingCancelled; }
    set { _planingCancelled = value; }
  }

  /// <summary>
  /// Set a List<Meal> instance to use dependency injection
  /// </summary>
  /// <param name="meals">A List<Meal> containing all the user Meals</param>
  public void SetMealsData(List<Meal> meals)
  {
    _mealsData = meals;
  }

  /// <summary>
  /// Verify if the meal includes a Side Dish
  /// </summary>
  /// <returns></returns>
  public bool includesSideDish()
  {
    if (_mealsID.Count > 1)
    {
      return true;
    }

    return false;
  }

  /// <summary>
  /// Edit one of the planned day parameters (Date, Main Meal, Side Dish)
  /// </summary>
  /// <param name="mainMealsDict">Dictionary containing the Main meals ID and Name</param>
  /// <param name="sideDishesDict">Dictionary containing the Side Dishes ID and Name</param>
  public void Edit(Dictionary<int, string> userMeals, Dictionary<int, string> userSideDishes)
  {
    Console.CursorVisible = false;

    string editPlanPrompt = "What do you want to change?";
    var editPlanOptions = new List<string>();
    editPlanOptions.Add("Change the date");
    editPlanOptions.Add("Change Meal");
    editPlanOptions.Add("Change/Add Side Dish");

    string selectedEditOption;
    selectedEditOption = Menu.GetSelectedOption(editPlanPrompt, editPlanOptions);

    if (selectedEditOption == "Change the date")
    {
      Console.WriteLine();

      DateTime? date = Utils.GetDate();

      this.Date = date.Value;

      Utils.DisplayMessage($"\n(!) Date changed to {date.Value.ToShortDateString()}\n", type: "info", speed: 2);
    }
    else if (selectedEditOption == "Change Meal")
    {
      string mealPrompt = "Select a new meal: ";
      int? selectedMealId = Utils.GetSelectedKeyFromDict(prompt: mealPrompt, idAndNameDict: userMeals);

      if (selectedMealId == null)
      {
        this.IsPlanningCancelled = true;
        return;
      }

      this.MealIDs[0] = selectedMealId.Value;

      Utils.DisplayMessage($"\n(!) Meal changed to {userMeals[selectedMealId.Value]}\n", type: "info", speed: 2);
    }
    else if (selectedEditOption == "Change/Add Side Dish")
    {

      string sideDishPrompt = "Select a new Side Dish: ";
      int? selectedSideDishId = Utils.GetSelectedKeyFromDict(prompt: sideDishPrompt, idAndNameDict: userSideDishes);

      if (selectedSideDishId == null)
      {
        this.IsPlanningCancelled = true;
        return;
      }

      if (MealIDs.Count > 1)
      {
        this.MealIDs[1] = selectedSideDishId.Value;
      }
      else
      {
        this.MealIDs.Add(selectedSideDishId.Value);
      }

      // ToDo: What if mealsIDs is zero?

      Utils.DisplayMessage($"\n(!) Side dish changed to {userSideDishes[selectedSideDishId.Value]}\n", type: "info", speed: 2);
    }
    else if (selectedEditOption == null)
    {
      this.IsPlanningCancelled = true;
    }
  }

  /// <summary>
  /// Display the planned day data in the console
  /// </summary>
  /// <param name="mealsDict">Dictionary containing the meals ID and Name</param>
  public void DisplayPlannedDay(Dictionary<int, string> mealsDict)
  {
    Utils.DisplayMessage($"- Date: {Date.ToShortDateString()}\n");
    Utils.DisplayMessage($"- Main: {mealsDict[MealIDs[0]]}\n");
    if (MealIDs.Count > 1)
    {
      Utils.DisplayMessage($"- Side Dish: {mealsDict[MealIDs[1]]}\n");
    }
  }

  public List<string> GetPlannedDayDataList()
  {
    var plannedDayDataList = new List<string>();

    Meal mainMeal = _mealsData.Find(meal => meal.Id == MealIDs[0]);
    string mealName = mainMeal.Name;

    string sideDishName = "";
    if (MealIDs.Count > 1)
    {
      Meal sideDish = _mealsData.Find(meal => meal.Id == MealIDs[1]);
      sideDishName = sideDish.Name;
    }

    string completed = IsCompleted ? "X" : "";

    plannedDayDataList.Add(Id.ToString());
    plannedDayDataList.Add(Date.ToShortDateString());
    plannedDayDataList.Add(mealName);
    plannedDayDataList.Add(sideDishName);
    plannedDayDataList.Add(completed);

    return plannedDayDataList;
  }
}