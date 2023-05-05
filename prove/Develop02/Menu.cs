// Responsibilities:
// - Display the menu options to the user
// - Get and manage the selected option

/// <summary>
/// Class <c>Menu</c> defines a menu with a header and options.
/// </summary>
public class Menu
{
    public string _header;
    public List<string> _options = new List<string>();

    /// <summary>
    /// Constructs a new instance of the Menu class.
    /// </summary>
    /// <param name="header">The first message of the menu.</param>
    /// <param name="options">The list of options to display.</param>
    public Menu(string header, List<string> options)
    {
        _header = header;

        for (int option = 0; option < options.Count(); option++)
        {
            _options.Add($"{option+1} - {options[option]}");
        }
    }

    public void DisplayMenu()
    {
        Console.WriteLine(_header);
        
        foreach (string option in _options)
        {
            Console.WriteLine(option);
        }
    }

}