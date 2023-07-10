/// <summary>
/// Construct a Menu to display a list of options to the user ///---and handle the selected Option---///
/// </summary>
public class Menu
{
  private Dictionary<string, string> _options = new Dictionary<string, string>();

  public Menu()
  {

  }

  /// <summary>
  /// Instantiate a Menu with the given options
  /// </summary>
  /// <param name="options">A Dictionary containing a list of options</param>
  public Menu(Dictionary<string, string> options)
  {
    _options = options;
  }

  /// <summary>
  /// Display the menu options
  /// </summary>
  public void DisplayOptions(Dictionary<string, string> options)
  {
    Utils.DisplayText("\nMenu Options:\n");
    foreach (KeyValuePair<string, string> option in options)
    {
      Utils.DisplayText($"{option.Key} - {option.Value}\n");
    }
    Utils.DisplayText("\n> Select a choice from the menu: ");
  }

  public void DisplayOptions()
  {
    List<string> _options = new List<string>();
    _options.Add("");
  }

  public static void DisplayWelcome()
  {
    Utils.DisplayText("Welcome to the Meal Tracker!\n");
    Utils.DisplayText("We have prepared a list of meals and ingredients for you to start " +
    " planning your next meals ASAP! \n");
  }
}
