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
    Utils.TextAnimation("\nMenu Options:\n");
    foreach (KeyValuePair<string, string> option in options)
    {
      Utils.TextAnimation($"{option.Key} - {option.Value} \n");
    }
    Utils.TextAnimation("\n> Select a choice from the menu: ");
  }

  public void DisplayOptions()
  {
    List<string> _options = new List<string>();
    _options.Add("");
  }

  public void DisplayWelcome()
  {
    Utils.TextAnimation("Welcome to the Meal Tracker! \n");
    Utils.TextAnimation("We have prepared a list of meals and ingredients for you to START " +
    "planning your next meals ASAP! \n");
  }
}
