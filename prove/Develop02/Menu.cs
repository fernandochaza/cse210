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

    public void DisplayOptions()
    {
        foreach (string option in _options)
        {
            Console.WriteLine(option);
        }

        Console.Write("What would you like to do? ");
    }

    public void DisplayHeader()
    {
        Console.WriteLine(_header);
    }

    // Commented. I'm not sure what to do after getting the user's input
    // public void getInput()
    // {
    //     switch (Console.ReadLine())
    //     {
    //         case "1":
    //             int userInput = 1;
    //             Console.WriteLine(userInput);
    //             break;
            
    //         case "2":
    //             userInput = 2;
    //             break;
    //     }

    // }

}