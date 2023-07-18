using ConsoleTables;

/// <summary>
/// Construct a Menu to display a list of options to the user ///---and handle the selected Option---///
/// </summary>
public static class Menu
{

  /// <summary>
  /// Display the menu options
  /// </summary>
  public static void DisplayOptions(Dictionary<string, string> options)
  {
    Utils.DisplayMessage("\nMenu Options:\n");
    foreach (KeyValuePair<string, string> option in options)
    {
      Utils.DisplayMessage($"{option.Key} - {option.Value} \n");
    }
    Utils.DisplayMessage("\n> Select a choice from the menu: ");
  }

  public static void DisplayOptions()
  {
    List<string> _options = new List<string>();
    _options.Add("");
  }

  public static void DisplayWelcome()
  {
    Utils.DisplayMessage("--------------------------------------\n\n");
    Utils.DisplayMessage("---------- MEAL PLANNING APP ---------\n\n");
    Utils.DisplayMessage("--------------------------------------\n\n");


    Console.ForegroundColor = ConsoleColor.Red;
    Utils.DisplayMessage("(!) Keyboard navigation:\n");

    Console.ForegroundColor = ConsoleColor.Green;
    Utils.DisplayMessage("- Use ARROW UP / ARROW DOWN to navigate the options\n");
    Utils.DisplayMessage("- Use ESC to CANCEL or GO BACK to the previous menu\n");
    Utils.DisplayMessage("- Use Enter to confirm an input\n");
    Console.ResetColor();

    Utils.DisplayMessage("\n-> We have prepared a list of meals and ingredients for you to " +
    "START planning your next meals ASAP! \n");
    Console.ResetColor();
  }

  public static string GetSelectedOption(string prompt, List<string> options, ConsoleTable displayTableTop = null, ConsoleTable displayTableBottom = null)
  {
    ConsoleKeyInfo keyInfo;
    int selectedIndex = 0;

    Console.CursorVisible = false;

    do
    {
      Console.Clear();

      if (displayTableTop != null)
      {
        displayTableTop.Write(Format.Minimal);
        Console.WriteLine();
      }

      if (prompt != "")
      {
        Console.WriteLine($"{prompt}\n");
      }

      for (int i = 0; i < options.Count; i++)
      {
        if (i == selectedIndex)
        {
          Console.Write("-> ");
        }
        else
        {
          Console.Write("   ");
        }

        // Display the option text
        string optionText = options[i];
        Console.WriteLine(optionText);
      }

      // Display bottom table
      if (displayTableBottom != null)
      {
        Console.WriteLine("\n");
        displayTableBottom.Write(Format.Minimal);
      }

      keyInfo = Console.ReadKey();

      if (keyInfo.Key == ConsoleKey.UpArrow)
      {
        selectedIndex = (selectedIndex + options.Count - 1) % options.Count;
      }
      else if (keyInfo.Key == ConsoleKey.DownArrow)
      {
        selectedIndex = (selectedIndex + 1) % options.Count;
      }
      else if (keyInfo.Key == ConsoleKey.Escape)
      {
        return null;
      }

    } while (keyInfo.Key != ConsoleKey.Enter);

    // Return the selected index
    return options[selectedIndex];
  }
}
