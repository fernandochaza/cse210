using System.Text.Json;
using System.Text.Json.Serialization;

public class PlannedDay
{
  private DateTime _date;
  // private Meal _plannedMeal;  //This should be an ID referencing to a Meal
  private List<int> _mealsID = new List<int>();  //This should be an ID referencing to a Meal
  private bool _isCompleted;
  private bool _isSkipped;

  [JsonConstructor]
  public PlannedDay()
  {

  }

  /// <summary>
  /// Instantiate a new PlannedDay from the user input
  /// </summary>
  /// <param name="userMeals"></param>
  public PlannedDay(Dictionary<int, string> userMeals, Dictionary<int, string> userSideDishes)
  {
    int day = Utils.GetUserInt("Insert the day number: ");
    int month = Utils.GetUserInt("Insert the month number: ");
    int currentYear = DateTime.Today.Year;
    DateTime date = new DateTime(currentYear, month, day);

    string prompt = "Do you want to include a Side Dish?";

    List<string> options = new List<string>();
    options.Add("Yes");
    options.Add("No");

    int? selectedOptionIndex = Utils.GetSelectedIndexFromList(prompt, options);

    if (selectedOptionIndex == null)
    {
      return; // Exit the method if Escape was pressed
    }

    string includesSideDish = options[selectedOptionIndex.Value];

    Utils.TextAnimation("Select a meal: ");
    int? selectedMealId = Utils.GetSelectedKeyFromDict(userMeals);

    if (selectedMealId == null)
    {
      return;
    }

    _mealsID.Add(selectedMealId.Value);

    if (includesSideDish == "Yes")
    {
      Utils.TextAnimation("Select a Side Dish: ");
      int? selectedSideDishId = Utils.GetSelectedKeyFromDict(userSideDishes);
      if (selectedSideDishId == null)
      {
        return;
      }
      _mealsID.Add(selectedSideDishId.Value);
    }

    _date = date;
    _isCompleted = false;
    _isSkipped = false;
  }

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

  public void Display(List<Meal> userMeals)
  {
    Console.WriteLine();

    // Display Date
    Utils.TextAnimation($"{_date.DayOfWeek} - {_date.ToShortDateString()} \n");

    // Create a new variable containing a list of the User Meals that match the PlannedDay Meals
    IEnumerable<Meal> matchingMeals = userMeals.Where(meal => _mealsID.Contains(meal.Id));

    // Display the Matching Meals
    foreach (Meal matchingMeal in matchingMeals)
    {
      matchingMeal.Display();
    }

    Console.WriteLine(_isCompleted);
    Console.WriteLine(IsSkipped);
  }

  public bool includesSideDish()
  {
    if (_mealsID.Count > 1)
    {
      return true;
    }

    return false;
  }

  // public string Serialize()
  // {
  //   var options = new JsonSerializerOptions
  //   {
  //     // Add indentation to the json data
  //     WriteIndented = true
  //   };

  //   // Serialize the current Planned Day instance
  //   string jsonString = JsonSerializer.Serialize(this, options);
  //   Console.WriteLine($"PLANNED DAY JSON: \n {jsonString}");

  //   // Option 1: Write the data in a file (Currently, this overrides the file)
  //   File.WriteAllText("planned-day.json", jsonString);

  //   // Option 2: Return the JSONString
  //   return jsonString;
  // }

  // public void Deserialize()
  // {
  //   // Read the data (Currently, this is only one planned day)
  //   string jsonString = File.ReadAllText("planned-day.json");

  //   var options = new JsonSerializerOptions();
  //   options.Converters.Add(new JsonStringEnumConverter());

  //   PlannedDay deserializedPlannedDay = JsonSerializer.Deserialize<PlannedDay>(jsonString, options);

  //   // Option 1: Return the PlannedDay
  //   // Return deserializedPlannedDay;

  //   // Option 2: Pass the values to the current PlannedDay

  // }
}