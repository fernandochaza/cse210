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
        { "1", "Start Breathing Activity" },
        { "2", "Start Reflection Activity" },
        { "3", "Start Enumeration Activity" },
        { "4", "Quit" },
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
        Console.Write("\n> What would you like to do? (Select an option): ");
    }

    /// <summary>
    /// Displays the menu welcome message
    /// </summary>
    /// <param name="userName">A variable containing the name of the user</param>
    /// <returns></returns>
    public void DisplayWelcome(string userName)
    {
        Console.WriteLine($"Hello {userName}! Welcome to your Mindfulness Tool\n");
    }
}