using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using ConsoleTables;

public class Meal
{
  private int _id;
  private static int _lastId = 0;
  private string _name;
  private bool _mealCreationCanceled = false;
  private MealType _type;
  private List<int> _ingredientsID = new List<int>();
  private List<Ingredient> _ingredientsData;

  [JsonConstructor]
  public Meal()
  {

  }

  public Meal(int mealId, List<Ingredient> ingredientsData)
  {
    SetIngredientsData(ingredientsData);
    Console.CursorVisible = true;
    Id = mealId;

    Utils.DisplayMessage("Please, insert the Meal name: ");
    Name = Console.ReadLine();

    Utils.DisplayMessage("Insert the Meal type (main or side dish): ");
    string type = Console.ReadLine();

    type = type.ToLower();

    if (type.Contains("main"))
    {
      Type = MealType.Main;
    }
    else if (type.Contains("side"))
    {
      Type = MealType.Side_Dish;
    }
    else
    {
      Utils.DisplayMessage("\n(!) Type error. Please, enter a valid type...\n\n", type: "warning", speed: 1);
      Utils.MessageToContinueAndClear();
      IsMealCreationCanceled = true;
      Console.CursorVisible = false;
      return;
    }

    // Add ingredients from Ingredients database or create new ingredients
    int ingredientsQuantity = Utils.GetUserInt("How many ingredients do you want to add to this meal? ");

    // ADD INGREDIENTS
    for (int i=0; i < ingredientsQuantity; i++)
    {
      string ingredientName = "";

      Console.CursorVisible = true;
      Utils.DisplayMessage("\nPlease, enter the name of the ingredient you want to Add: ");
      string searchedIngredient = Console.ReadLine();
      Console.CursorVisible = false;

      List<Ingredient> ingredientsFound = FindIngredientByName(searchedIngredient);

      int? selectedIngredientId = null;
      if (ingredientsFound.Count > 0)
      {
        var ingredientOptions = new Dictionary<int, string>();
        foreach (Ingredient ingredient in ingredientsFound)
        {
          ingredientOptions[ingredient.Id] = ingredient.Name;
        }

        selectedIngredientId = Utils.GetSelectedKeyFromDict(prompt: "Select the ingredient you want to add", idAndNameDict: ingredientOptions);
        if (selectedIngredientId == null)
        {
          IsMealCreationCanceled = true;
          Console.CursorVisible = false;
          return;
        }
        IngredientsID.Add(selectedIngredientId.Value);
        ingredientName = ingredientOptions[selectedIngredientId.Value];
      }

      Utils.DisplayMessage($"\n(!) {ingredientName} was added...");
      Utils.MessageToContinueAndClear();
    }
  }

  // Declare getters and setters to allow private members serialization
  // Use JsonPropertyName to define a key name for the Json file

  [JsonPropertyName("meal-id")]
  public int Id
  {
    get { return _id; }
    set { _id = value; }
  }

  [JsonPropertyName("meal-name")]
  public string Name
  {
    get { return _name; }
    set { _name = value; }
  }

  [JsonPropertyName("meal-type")]
  public MealType Type
  {
    get { return _type; }
    set
    {
      // Validate that the meal type is either Main or SideDish
      if (value == MealType.Main || value == MealType.Side_Dish)
        _type = value;
      else
        throw new ArgumentException("Invalid meal type.");
    }
  }

  [JsonPropertyName("meal-ingredients")]
  public List<int> IngredientsID
  {
    get { return _ingredientsID; }
    set { _ingredientsID = value; }
  }

  [JsonIgnore]
  public bool IsMealCreationCanceled
  {
    get { return _mealCreationCanceled; }
    set { _mealCreationCanceled = value; }
  }

  public enum MealType
  {
    Main,
    Side_Dish
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
  /// Display the capitalized Meal Name
  /// </summary>
  public void Display()
  {
    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
    string mealName = textInfo.ToTitleCase(_name);

    Utils.DisplayMessage($"{mealName}\n");
  }

  private static int GetNextId()
  {
    return ++_lastId;
  }

  internal void EditMealIngredients(Dictionary<int, string> ingredientsDatabaseDict)
  {
    var editIngredientOptions = new List<string>();
    editIngredientOptions.Add("Add");
    editIngredientOptions.Add("Remove");

    string selectedEditIngredientOption;
    do
    {
      string mealIngredientsPrompt = $"{Name} Ingredients";

      ConsoleTable mealIngredientsTable = DisplayMealIngredientsAsTable();
      selectedEditIngredientOption = Menu.GetSelectedOption(prompt: mealIngredientsPrompt, options: editIngredientOptions, displayTableTop: mealIngredientsTable);

      if (selectedEditIngredientOption == "Add")
      {
        Console.Clear();

        Console.CursorVisible = true;
        Utils.DisplayMessage("\nPlease, enter the name of the ingredient you want to Add: ");
        string searchedIngredient = Console.ReadLine();
        Console.CursorVisible = false;

        List<Ingredient> ingredientsFound = FindIngredientByName(searchedIngredient);

        int? selectedIngredientId = null;
        if (ingredientsFound.Count > 0)
        {
          var ingredientOptions = new Dictionary<int, string>();
          foreach (Ingredient ingredient in ingredientsFound)
          {
            ingredientOptions[ingredient.Id] = ingredient.Name;
          }

          selectedIngredientId = Utils.GetSelectedKeyFromDict(prompt: "Select the ingredient you want to add", idAndNameDict: ingredientOptions);
          IngredientsID.Add(selectedIngredientId.Value);
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Utils.DisplayMessage($"\n(!) {ingredientsDatabaseDict[selectedIngredientId.Value]} was added...");
        Console.ResetColor();
        Utils.MessageToContinueAndClear();

      }
      else if (selectedEditIngredientOption == "Remove")
      {
        Console.Clear();
        Utils.DisplayMessage($"{Name} Ingredients:\n");
        DisplayMealIngredientsAsTable();

        int ingredientToRemoveId = Utils.GetUserInt("\nPlease, enter the ID of the ingredient you want to remove and press Enter: ");
        IngredientsID.Remove(ingredientToRemoveId);

        Console.ForegroundColor = ConsoleColor.Red;
        Utils.DisplayMessage($"\n(!) {ingredientsDatabaseDict[ingredientToRemoveId]} was removed...");
        Console.ResetColor();
        Utils.MessageToContinueAndClear();
      }

    } while (selectedEditIngredientOption != null);
  }

  public ConsoleTable DisplayMealIngredientsAsTable()
  {
    var tableHeaders = new List<string>();
    tableHeaders.Add("Id");
    tableHeaders.Add("Name");

    ConsoleTable mealIngredientsTable = new ConsoleTable(tableHeaders.ToArray());

    var ingredientsList = new List<List<string>>();

    foreach (int ingredientId in IngredientsID)
    {
      var ingredientData = new List<string>();

      Ingredient ingredient = _ingredientsData.FirstOrDefault(ingredient => ingredient.Id == ingredientId);
      string ingredientName = ingredient.Name;

      ingredientData.Add(ingredientId.ToString());
      ingredientData.Add(ingredientName);
      ingredientsList.Add(ingredientData);
    }

    foreach (List<string> ingredient in ingredientsList)
    {
      mealIngredientsTable.AddRow(ingredient.ToArray());
    }

    mealIngredientsTable.Write();

    return mealIngredientsTable;
  }

  public List<Ingredient> FindIngredientByName(string searchString)
  {
    string lowerSearchString = searchString.ToLower();
    List<Ingredient> ingredientSearched = _ingredientsData.FindAll(ingredient => ingredient.Name.ToLower().Contains(lowerSearchString));
    return ingredientSearched;
  }
}