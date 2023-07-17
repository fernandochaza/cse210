using System.Text.Json;
using System.Text.Json.Serialization;

public class PlannedDay
{
  private int _id;
  private static int _lastId = 0;
  private DateTime _date;
  private List<int> _mealsID = new List<int>();
  private bool _isCompleted;
  private bool _isSkipped;
  private bool _planingCancelled = false;

  [JsonConstructor]
  public PlannedDay()
  {
    _lastId++;
  }

  /// <summary>
  /// Instantiate a new PlannedDay from the user input
  /// </summary>
  /// <param name="userMeals"></param>
  public PlannedDay(Dictionary<int, string> userMeals, Dictionary<int, string> userSideDishes)
  {
    int day = Utils.GetUserInt("Insert the day of the month: ");
    int month = Utils.GetUserInt("Insert the month number: ");
    int currentYear = DateTime.Today.Year;
    DateTime date = new DateTime(currentYear, month, day);

    string prompt = "Do you want to include a Side Dish?";

    List<string> options = new List<string>();
    options.Add("Yes");
    options.Add("No");

    Console.Clear();
    string includeSideDish = Menu.GetSelectedOption(prompt, options);

    if (includeSideDish == null)
    {
      IsPlanningCancelled = true;
      return;
    }

    string mealPrompt = "Select a meal: ";
    int? selectedMealId = Utils.GetSelectedKeyFromDict(mealPrompt, userMeals);

    if (selectedMealId == null)
    {
      IsPlanningCancelled = true;
      return;
    }

    _mealsID.Add(selectedMealId.Value);

    if (includeSideDish == "Yes")
    {
      string sideDishPrompt = "Select a Side Dish: ";
      int? selectedSideDishId = Utils.GetSelectedKeyFromDict(sideDishPrompt, userSideDishes);
      if (selectedSideDishId == null)
      {
        IsPlanningCancelled = true;
        return;
      }
      _mealsID.Add(selectedSideDishId.Value);
    }

    _id = GetNextId();
    _date = date;
    _isCompleted = false;
    _isSkipped = false;

    Utils.TextAnimation("\n(!) Meal successfully planned!\n");
    Display(userMeals, userSideDishes);
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

  [JsonPropertyName("skipped")]
  public bool IsSkipped
  {
    get { return _isSkipped; }
    set { _isSkipped = value; }
  }

  [JsonIgnore]
  public bool IsPlanningCancelled
  {
    get { return _planingCancelled; }
    set {_planingCancelled = value; }
  }

  public bool includesSideDish()
  {
    if (_mealsID.Count > 1)
    {
      return true;
    }

    return false;
  }

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
      int day = Utils.GetUserInt("Please, enter the day number: ");
      int month = Utils.GetUserInt("Please, enter the month number: ");
      int currentYear = DateTime.Today.Year;
      DateTime date = new DateTime(currentYear, month, day);

      this.Date = date;

      Utils.TextAnimation($"\n(!) Date changed to {date.ToShortDateString()}\n");
    }
    else if (selectedEditOption == "Change Meal")
    {
      string mealPrompt = "Select a new meal: ";
      int? selectedMealId = Utils.GetSelectedKeyFromDict(mealPrompt, userMeals);

      if (selectedMealId == null)
      {
        this.IsPlanningCancelled = true;
        return;
      }

      this.MealIDs[0] = selectedMealId.Value;
      Utils.TextAnimation($"\n(!) Meal changed to {userMeals[selectedMealId.Value]}\n");
    }
    else if (selectedEditOption == "Change/Add Side Dish")
    {

      string sideDishPrompt = "Select a new Side Dish: ";
      int? selectedSideDishId = Utils.GetSelectedKeyFromDict(sideDishPrompt, userSideDishes);

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

      Utils.TextAnimation($"\n(!) Side dish changed to {userSideDishes[selectedSideDishId.Value]}\n");
    }
    else if (selectedEditOption == null)
    {
      this.IsPlanningCancelled = true;
    }
  }

  public void Display(Dictionary<int, string> userMeals, Dictionary<int, string> userSideDishes)
  {
    Utils.TextAnimation($"- Date: {Date.ToShortDateString()}\n");
    Utils.TextAnimation($"- Main: {userMeals[MealIDs[0]]}\n");
    if (MealIDs.Count > 1)
    {
      Utils.TextAnimation($"- Side Dish: {userSideDishes[MealIDs[1]]}\n");
    }
  }

  private static int GetNextId()
  {
    return ++_lastId;
  }
}