using System.ComponentModel;
using System.Reflection;
/// <summary>
/// Class <c>Menu</c> defines a menu with a header and options.
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
        { "1", "Display all my scriptures" },
        { "2", "Add a new Scripture" },
        { "3", "Memorize a Scripture" },
        { "4", "Quit" },
        };
    }

    /// <summary>
    /// Display the menu options
    /// </summary>
    public void DisplayOptions()
    {
        Console.WriteLine();
        foreach (KeyValuePair<string, string> option in _options)
        {
            Console.WriteLine($"{option.Key} - {option.Value}");
        }
        Console.Write("What would you like to do? ");
    }

    /// <summary>
    /// Displays the menu welcome message
    /// </summary>
    /// <param name="userName">A variable containing the name of the user</param>
    /// <returns></returns>
    public void DisplayWelcome(string userName)
    {
        Console.WriteLine($"Hello {userName}! Welcome to the Scripture Memorizer");
    }
}