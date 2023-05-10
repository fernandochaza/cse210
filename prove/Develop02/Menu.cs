using System.ComponentModel;
using System.Reflection;
// Responsibilities:
// - Display the menu options to the user
// - Get and manage the selected option

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
        { "1", "Create a new entry" },
        { "2", "Display my journal" },
        { "3", "Prompt Manager: Display all the prompts" },
        { "4", "Prompt Manager: Add a prompt" },
        { "5", "Prompt Manager: Remove a prompt" },
        { "6", "Quit" },
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
        Console.WriteLine($"Hello {userName}! Welcome to your Journal Manager");
    }
}