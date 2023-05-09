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
    public List<string> _options = new List<string>();
    public enum MenuOption
    {
        [Description("Create a new entry")]
        Option1,
        [Description("Display my journal")]
        Option2,
        [Description("Save today's entries")]
        Option3,
        [Description("Load my journal")]
        Option4,
        [Description("Quit")]
        Option5
    }

    /// <summary>
    /// Constructs a new instance of the Menu class.
    /// </summary>
    public Menu()
    {
        foreach (MenuOption option in Enum.GetValues(typeof(MenuOption)))
        {
            string description = option.GetType()
            .GetMember(option.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<DescriptionAttribute>()
            ?.Description;

            _options.Add($"{(int)option + 1} - {description}");
        }
    }

    /// <summary>
    /// Display the menu options
    /// </summary>
    public void DisplayOptions()
    {
        foreach (string option in _options)
        {
            Console.WriteLine(option);
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