using System.Text.Json;
using System.Text.Json.Serialization;
using ConsoleTables;

public class MealManager
{
  private List<Ingredient> _ingredients = new List<Ingredient>();
  private List<Meal> _meals = new List<Meal>();
  private bool _addingCancelled = false;
  private Planner _planner;

  // Declare getters and setters to allow private members serialization
  // Use JsonPropertyName to define a key name for the Json file

  [JsonPropertyName("user-ingredients")]
  public List<Ingredient> Ingredients
  {
    get { return _ingredients; }
    set { _ingredients = value; }
  }

  [JsonPropertyName("user-meals")]
  public List<Meal> Meals
  {
    get { return _meals; }
    set { _meals = value; }
  }

  [JsonIgnore]
  public bool IsAddingCancelled
  {
    get { return _addingCancelled; }
    set { _addingCancelled = value; }
  }

  /// <summary>
  /// Set a Planner instance to use dependency injection
  /// </summary>
  /// <param name="planner">The main Planner Class instance containing the user data</param>
  public void SetPlanner(Planner planner)
  {
    _planner = planner;
  }

  public void AddNewMeal()
  {
    int id = GetNewMealId();
    List<Ingredient> ingredientsData = _ingredients;

    Meal newMeal = new Meal(id, ingredientsData);
    if (!newMeal.IsMealCreationCanceled)
    {
      _meals.Add(newMeal);
      Utils.DisplayMessage("\nNew Meal:\n");
      newMeal.Display();
      newMeal.DisplayMealIngredientsAsTable();
    }
    else
    {
      IsAddingCancelled = true;
    }
  }

  public void RemoveMeal()
  {
    DisplayMealsTable();

    // Display the cursor
    Console.CursorVisible = true;

    int mealToRemoveId = Utils.GetUserInt("Please, enter the ID of the Meal you want to remove: ");

    // Get meals ids to verify user input
    Dictionary<int, string> mealsDict = GenerateMealsDictionary();
    if (!mealsDict.Keys.Contains(mealToRemoveId))
    {
      Utils.DisplayMessage($"\n(!) The id {mealToRemoveId} doesn't match an existing Meal!...\n", type: "warning", speed: 2);
      Utils.MessageToContinueAndClear();
      return;
    }

    Meal mealToRemove = _meals.FirstOrDefault(meal => meal.Id == mealToRemoveId);

    if (mealToRemove != null)
    {
      _meals.Remove(mealToRemove);
      Utils.DisplayMessage("\n(!) The selected Meal was successfully removed...\n", type: "info", speed: 1);
      mealToRemove.Display();
    }
  }

  public void AddNewIngredient()
  {
    int id = GetNewIngredientId();

    Ingredient newIngredient = new Ingredient(id);

    if (!newIngredient.IsIngredientCreationCanceled)
    {
      _ingredients.Add(newIngredient);
      Utils.DisplayMessage("\nNew Ingredient:\n");
      newIngredient.Display();
    }
    else
    {
      IsAddingCancelled = true;
    }
  }

  public void RemoveIngredient()
  {
    DisplayIngredientsTable();

    // Display the cursor
    Console.CursorVisible = true;

    int ingredientToRemoveId = Utils.GetUserInt("Please, enter the ID of the Ingredient you want to remove: ");

    // Get ingredients ids to verify user input
    Dictionary<int, string> ingredientsDict = GenerateIngredientsDictionary();
    if (!ingredientsDict.Keys.Contains(ingredientToRemoveId))
    {
      Utils.DisplayMessage($"\n(!) The id {ingredientToRemoveId} doesn't match an existing Ingredient!...\n", type: "warning", speed: 2);
      Utils.MessageToContinueAndClear();
      return;
    }

    Ingredient ingredientToRemove = _ingredients.FirstOrDefault(ingredient => ingredient.Id == ingredientToRemoveId);

    if (ingredientToRemove != null)
    {
      _ingredients.Remove(ingredientToRemove);
      Utils.DisplayMessage("\n(!) The selected Ingredient was successfully removed...\n", type: "info", speed: 1);
      ingredientToRemove.Display();
    }
  }

  public int GetNewIngredientId()
  {
    int newId = 1;

    foreach (Ingredient ingredient in _ingredients)
    {
      if (ingredient.Id > newId)
      {
        newId = ingredient.Id;
      }
    }

    newId++;

    return newId;
  }

  public int GetNewMealId()
  {
    int newId = 1;

    foreach (Meal meal in _meals)
    {
      if (meal.Id > newId)
      {
        newId = meal.Id;
      }
    }

    newId++;

    return newId;
  }

  /// <summary>
  /// Display a list of the user Main Meal Names
  /// </summary>
  public void DisplayMainMealsList()
  {
    List<Meal> mainMeals = GetMainMealsList();

    Utils.DisplayMessage("Main Meals:\n\n", type: "info");
    foreach (Meal meal in mainMeals)
    {
      meal.Display();
    }
  }

  /// <summary>
  /// Display a list of the user Side Dishes Names
  /// </summary>
  public void DisplaySideDishesList()
  {
    List<Meal> sideDishes = GetSideDishList();

    Utils.DisplayMessage("Side Dishes:\n\n", type: "info");
    foreach (Meal sideDish in sideDishes)
    {
      sideDish.Display();
    }
  }

  private string GetMealIngredientsString(Meal meal)
  {
    string ingredientsString = "";

    foreach (int ingredientId in meal.IngredientsID)
    {
      Ingredient ingredient = _ingredients.FirstOrDefault(ingredient => ingredient.Id == ingredientId);

      if (ingredient != null)
      {
        ingredientsString += ingredient.Name + " | ";
      }
    }

    if (!string.IsNullOrEmpty(ingredientsString))
    {
      ingredientsString = ingredientsString.TrimEnd('|', ' ');
    }

    return ingredientsString;
  }

  private ConsoleTable GetMealIngredientsTable(Meal meal)
  {
    var headers = new List<string>();
    headers.Add("Meal");
    headers.Add("Ingredients");

    var row = new List<string>();
    string mealName = meal.Name;
    string mealIngredients = GetMealIngredientsString(meal);

    row.Add(mealName);
    row.Add(mealIngredients);

    ConsoleTable table = new ConsoleTable(headers.ToArray());
    table.AddRow(row.ToArray());

    table.Write(Format.Minimal);

    return table;
  }

  private void DisplayMealsTable()
  {
    var headers = new List<string>();
    headers.Add("Id");
    headers.Add("Meal");

    ConsoleTable mealsTable = new ConsoleTable(headers.ToArray());

    foreach (Meal meal in _meals)
    {
      var mealRow = new List<string>();

      string mealId = meal.Id.ToString();
      string mealName = meal.Name;

      mealRow.Add(mealId);
      mealRow.Add(mealName);
      mealsTable.AddRow(mealRow.ToArray());

    }

    mealsTable.Write(Format.Minimal);
  }

  public void DisplayIngredientsTable()
  {
    var headers = new List<string>();
    headers.Add("Id");
    headers.Add("Ingredient");

    ConsoleTable ingredientsTable = new ConsoleTable(headers.ToArray());

    foreach (Ingredient ingredient in _ingredients)
    {
      var ingredientRow = new List<string>();

      string ingredientId = ingredient.Id.ToString();
      string ingredientName = ingredient.Name;

      ingredientRow.Add(ingredientId);
      ingredientRow.Add(ingredientName);
      ingredientsTable.AddRow(ingredientRow.ToArray());

    }

    ingredientsTable.Write(Format.Minimal);
  }


  public void VerifyMealIngredients(Dictionary<int, string> mealsToCheckDict)
  {
    int? selectedMealId;

    // Ask the user to select a Meal from a dict to get the Id
    selectedMealId = Utils.GetSelectedKeyFromDict(prompt: "Select a Meal to verify the ingredients: ", idAndNameDict: mealsToCheckDict);

    if (selectedMealId == null)
    {
      return;
    }

    // Get the instance of the Meal to verify
    Meal selectedMeal = Meals.Find(meal => meal.Id == selectedMealId);

    Console.WriteLine();

    string selectedIngredientOption;
    do
    {
      // Display edit options
      var ingredientsOptions = new List<string>();
      ingredientsOptions.Add("Edit Ingredients");

      // Meal table to display inside the option selector
      ConsoleTable mealTable = GetMealIngredientsTable(selectedMeal);

      // Get the selected option
      selectedIngredientOption = Menu.GetSelectedOption(prompt: "", ingredientsOptions, displayTableTop: mealTable);

      if (selectedIngredientOption == "Edit Ingredients")
      {
        Dictionary<int, string> ingredientsDatabaseDict = GenerateIngredientsDictionary();
        selectedMeal.EditMealIngredients(ingredientsDatabaseDict);
      }
    } while (selectedIngredientOption != null);
  }

  private List<Meal> GetMainMealsList()
  {
    var mainMeals = new List<Meal>();

    mainMeals = _meals.Where(meal => meal.Type == Meal.MealType.Main).ToList();

    return mainMeals;
  }

  private List<Meal> GetSideDishList()
  {
    var sideDishes = new List<Meal>();

    sideDishes = _meals.Where(meal => meal.Type == Meal.MealType.Side_Dish).ToList();

    return sideDishes;
  }

  public Dictionary<int, string> GenerateMealsDictionary()
  {
    var mealsDict = new Dictionary<int, string>();
    foreach (Meal meal in _meals)
    {
      int mealId = meal.Id;
      mealsDict[mealId] = meal.Name;
    }

    return mealsDict;
  }

  public Dictionary<int, string> GenerateMainMealsDictionary()
  {
    var mainMealsDict = new Dictionary<int, string>();
    foreach (Meal meal in _meals)
    {
      if (meal.Type == Meal.MealType.Main)
      {
        int mealId = meal.Id;
        mainMealsDict[mealId] = meal.Name;
      }
    }

    return mainMealsDict;
  }

  public Dictionary<int, string> GenerateSideDishDictionary()
  {
    var sideDishDict = new Dictionary<int, string>();
    foreach (Meal meal in _meals)
    {
      if (meal.Type == Meal.MealType.Side_Dish)
      {
        int mealId = meal.Id;
        sideDishDict[mealId] = meal.Name;
      }
    }

    return sideDishDict;
  }

  private Dictionary<int, string> GenerateIngredientsDictionary()
  {
    var ingredientsDict = new Dictionary<int, string>();
    foreach (Ingredient ingredient in _ingredients)
    {
      int ingredientId = ingredient.Id;
      ingredientsDict[ingredientId] = ingredient.Name;
    }

    return ingredientsDict;
  }
}