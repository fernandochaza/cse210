/// <summary>
/// Construct a Menu to display a list of options to the user ///---and handle the selected Option---///
/// </summary>
public class Menu
{
    private Dictionary<string, string> _options = new Dictionary<string, string>();


  /// <summary>
  /// Instantiate a Menu with the given options
  /// </summary>
  /// <param name="options">A Dictionary containing a list </param>
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
}