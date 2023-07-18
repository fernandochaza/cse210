using System.Text.Json;
using System.Text.Json.Serialization;
using ConsoleTables;

public class MealManager
{
  private List<Ingredient> _ingredients = new List<Ingredient>();
  private List<Meal> _meals = new List<Meal>();
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
  
  public void SetPlanner(Planner planner)
  {
    _planner = planner;
  }

  public void AddMeal(Meal meal)
  {
    _meals.Add(meal);
  }

  public void AddIngredient(Ingredient ingredient)
  {
    _ingredients.Add(ingredient);
  }

  public void AddIngredient()
  {

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
  /// Display a list of all the user Meal Names. Separating Main Meals from Side Dishes
  /// </summary>
  public void DisplayMealsList()
  {
    List<Meal> mainMeals = GetMainMealsList();
    List<Meal> sideDishes = GetSideDishList();

    Utils.TextAnimation("Main Meals:\n");
    foreach (Meal meal in mainMeals)
    {
      meal.Display();
    }

    Utils.TextAnimation("Side Dishes:\n");
    foreach (Meal sideDish in sideDishes)
    {
      sideDish.Display();
    }
  }

  /// <summary>
  /// Display a list of the user Main Meal Names
  /// </summary>
  public void DisplayMainMealsList()
  {
    List<Meal> mainMeals = GetMainMealsList();

    Utils.TextAnimation("Main Meals:\n");
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

    Utils.TextAnimation("Side Dishes:\n");
    foreach (Meal sideDish in sideDishes)
    {
      sideDish.Display();
    }
  }

  // public ConsoleTable DisplayMealAsTable(Meal meal)
  // {
  //   // Generate headers for the table
  //   var headers = new List<string>();
  //   headers.Add("Meal");
  //   headers.Add("Type");
  //   headers.Add("Ingredients");
  //   var table = new ConsoleTable(headers.ToArray());

  //   var mealData = new List<string>();
  //   string mealName = meal.Name;
  //   string mealType = meal.Type.ToString();
  //   string ingredients = GetMealIngredientsString(meal);

  //   mealData.Add(mealName);
  //   mealData.Add(mealType);
  //   mealData.Add(ingredients);

  //   table.AddRow(mealData.ToArray());

  //   table.Write(Format.Minimal);

  //   Utils.MessageToContinueAndClear();

  //   return table;
  // }

  // public ConsoleTable DisplayMealIngredientsAsTable(Meal meal)
  // {
  //   var ingredientsDatabaseDict = GenerateIngredientsDictionary();

  //   var tableHeaders = new List<string>();
  //   tableHeaders.Add("Id");
  //   tableHeaders.Add("Name");
  //   ConsoleTable mealIngredientsTable = new ConsoleTable(tableHeaders.ToArray());

  //   var ingredientsList = new List<List<string>>();

  //   foreach (int ingredientId in meal.IngredientsID)
  //   {
  //     var ingredientData = new List<string>();

  //     string ingredientName = ingredientsDatabaseDict[ingredientId];

  //     ingredientData.Add(ingredientId.ToString());
  //     ingredientData.Add(ingredientName);
  //     ingredientsList.Add(ingredientData);
  //   }

  //   foreach (List<string> ingredient in ingredientsList)
  //   {
  //     mealIngredientsTable.AddRow(ingredient.ToArray());
  //   }

  //   mealIngredientsTable.Write();

  //   return mealIngredientsTable;
  // }

  private string GetMealIngredientsString(Meal meal)
  {
    string ingredientsString = "";

    foreach (int ingredientId in meal.IngredientsID)
    {
      Ingredient ingredient = _ingredients.FirstOrDefault(ingredient => ingredient.Id == ingredientId);

      if (ingredient != null)
      {
        ingredientsString += ingredient.Name + ", ";
      }
    }

    if (!string.IsNullOrEmpty(ingredientsString))
    {
      ingredientsString = ingredientsString.TrimEnd(',', ' ');
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

    table.Write();

    return table;
  }

  public void VerifyIngredients(Dictionary<int, string> mealsToCheckDict)
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

  public List<Ingredient> FindIngredientByName(string searchString)
  {
    List<Ingredient> ingredientSearched = _ingredients.FindAll(ingredient => ingredient.Name.Contains(searchString));
    return ingredientSearched;
  }
}