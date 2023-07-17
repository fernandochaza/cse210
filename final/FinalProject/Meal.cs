using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using ConsoleTables;

public class Meal
{
  private int _id;
  private static int _lastId = 0;
  private string _name;
  private MealType _type;
  private List<int> _ingredientsID = new List<int>();

  public Meal()
  {

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

  public enum MealType
  {
    Main,
    Side_Dish
  }

  /// <summary>
  /// Instantiate a Meal object, populate its data from the user input and return it
  /// </summary>
  public static Meal Create()
  {
    Meal meal = new Meal();
    meal._id = GetNextId();

    Utils.TextAnimation("Meal name: \n");
    meal._name = Console.ReadLine();

    Utils.TextAnimation("Meal type (main or side dish): \n");
    string type = Console.ReadLine();

    if (type == "main")
    {
      meal._type = MealType.Main;
    }
    else if (type == "side dish")
    {
      meal._type = MealType.Side_Dish;
    }
    else
    {
      Utils.TextAnimation("Type error\n");
    }

    // Add ingredients from Ingredients database or create new ingredients
    int quantity;
    Utils.TextAnimation("how many ingredients? ");
    quantity = int.Parse(Console.ReadLine());

    // ------ ADD CODE TO ADD INGREDIENTS -----

    meal._ingredientsID.Add(1);
    meal._ingredientsID.Add(2);
    meal._ingredientsID.Add(3);

    return meal;
  }

  /// <summary>
  /// Display the Meal Name
  /// </summary>
  public void Display()
  {
    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
    string mealName = textInfo.ToTitleCase(_name);

    Utils.TextAnimation($"{mealName}\n");
  }

  public ConsoleTable DisplayMealIngredientsAsTable(Dictionary<int, string> ingredientsDatabaseDict)
  {
    var tableHeaders = new List<string>();
    tableHeaders.Add("Id");
    tableHeaders.Add("Name");
    ConsoleTable mealIngredientsTable = new ConsoleTable(tableHeaders.ToArray());

    var ingredientsList = new List<List<string>>();

    foreach (int ingredientId in _ingredientsID)
    {
      var ingredientData = new List<string>();

      string ingredientName = ingredientsDatabaseDict[ingredientId];

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

  public void EditIngredients(Dictionary<int, string> ingredientsDatabaseDict)
  {

    var editIngredientOptions = new List<string>();
    editIngredientOptions.Add("Add");
    editIngredientOptions.Add("Remove");

    string selectedEditIngredientOption;
    do
    {
      ConsoleTable mealIngredientsTable = DisplayMealIngredientsAsTable(ingredientsDatabaseDict);
      selectedEditIngredientOption = Menu.GetSelectedOption(prompt: "", options: editIngredientOptions, displayTableTop: mealIngredientsTable);

      if (selectedEditIngredientOption == "Add")
      {
        Console.Clear();

        // Todo: Display all the ingredients with their ID

        int ingredientToAddId = Utils.GetUserInt("\nPlease, enter the ID of the ingredient you want to Add and press Enter: ");
        _ingredientsID.Add(ingredientToAddId);

        Console.ForegroundColor = ConsoleColor.Red;
        Utils.TextAnimation($"\n(!) {ingredientsDatabaseDict[ingredientToAddId]} was added...");
        Console.ResetColor();
        Utils.MessageToContinueAndClear();

      }
      else if (selectedEditIngredientOption == "Remove")
      {
        Console.Clear();
        Utils.TextAnimation($"{Name} Ingredients:\n");
        DisplayMealIngredientsAsTable(ingredientsDatabaseDict);

        int ingredientToRemoveId = Utils.GetUserInt("\nPlease, enter the ID of the ingredient you want to remove and press Enter: ");
        _ingredientsID.Remove(ingredientToRemoveId);

        Console.ForegroundColor = ConsoleColor.Red;
        Utils.TextAnimation($"\n(!) {ingredientsDatabaseDict[ingredientToRemoveId]} was removed...");
        Console.ResetColor();
        Utils.MessageToContinueAndClear();
      }

    } while (selectedEditIngredientOption != null);



  }

  private static int GetNextId()
  {
    return ++_lastId;
  }
}