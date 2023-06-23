/// <summary>
/// Class <c>Menu</c> defines a menu with a welcome message and options.
/// </summary>
public class Menu
{
    private Dictionary<string, string> _options;

    /// <summary>
    /// Constructs a new instance of the Menu class.
    /// </summary>
    public Menu()
    {
        _options = new Dictionary<string, string>
        {
        { "1", "Create New Goal" },
        { "2", "List Goals" },
        { "3", "Save Goals" },
        { "4", "Load Goals" },
        { "5", "Record Event" },
        { "6", "Quit" }
        };
    }

    /// <summary>
    /// Display the menu options
    /// </summary>
    public void DisplayOptions()
    {
        Console.WriteLine("Menu Options:");
        foreach (KeyValuePair<string, string> option in _options)
        {
            Console.WriteLine($"{option.Key} - {option.Value}");
        }
        Console.Write("\n> Select a choice from the menu: ");
    }

    /// <summary>
    /// Displays the menu welcome message
    /// </summary>
    /// <param name="userName">A variable containing the name of the user</param>
    /// <returns></returns>
    public void DisplayWelcome(string userName)
    {
        Console.WriteLine($"Hello {userName}! Welcome again to your goals tracker\n");
    }
}