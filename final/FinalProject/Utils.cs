using ConsoleTables;

public static class Utils
{
  /// <summary>
  /// Display a prompt and validate an user integer input
  /// </summary>
  /// <param name="message">The prompt displayed to the user to ask for an integer input</param>
  /// <returns>A validated integer</returns>
  public static int GetUserInt(string prompt)
  {
    // Display the cursor
    Console.CursorVisible = true;

    string userInput;
    int validInteger = 0;
    bool isValidNumber = false;

    // Run this until the user input is valid
    while (!isValidNumber)
    {
      // Display the given prompt
      Utils.DisplayMessage(prompt);

      userInput = Console.ReadLine();

      // Try to parse the user input or display an error if its invalid
      if (int.TryParse(userInput, out validInteger))
      {
        isValidNumber = true;
      }
      else
      {
        Console.WriteLine("\n(!) Invalid input. Please enter a valid integer.");
      }
    }

    // Hide the cursor again
    Console.CursorVisible = false;

    return validInteger;
  }

  /// <summary>
  /// Create a text typing animation from a given text to give the user a better sense of
  /// what is being printed in the console
  /// </summary>
  /// <param name="text">The text to be displayed</param>
  public static void DisplayMessage(string text, int speed = 0, string type = null)
  {
    if (type != null)
    {
      type = type.ToLower();
    }

    // Set the message color
    if (type == "warning")
    {
      Console.ForegroundColor = ConsoleColor.Red;
    }
    else if (type == "success")
    {
      Console.ForegroundColor = ConsoleColor.Green;
    }
    else if (type == "info")
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
    }

    // Display the message
    int textLength = text.Length;
    for (int i = 0; i < textLength; i++)
    {
      Console.Write(text[i]);
      Thread.Sleep(speed);
    }

    // Reset console color to default
    Console.ResetColor();
  }

  /// <summary>
  /// Allow the user to decide when to continue by pressing a key before cleaning the console
  /// </summary>
  public static void MessageToContinueAndClear()
  {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.CursorVisible = false;
    Utils.DisplayMessage("\n> Press Enter to continue...");
    Console.ReadLine();
    Console.Clear();
    Console.ResetColor();
  }

  public static int? GetSelectedKeyFromDict(string prompt, Dictionary<int, string> idAndNameDict)
  {
    ConsoleKeyInfo keyInfo;

    // Generate a List of the dictionary keys that represents the object ID
    List<int> keysList = idAndNameDict.Keys.ToList();

    // This contain the user selected item as an index of the keysList variable
    int keyIndex = 0;

    do
    {
      Console.Clear();
      Utils.DisplayMessage($"{prompt}\n\n");

      for (int i = 0; i < keysList.Count; i++)
      {
        if (i == keyIndex)
        {
          Console.Write("-> ");
        }
        else
        {
          Console.Write("   ");
        }

        // Display the object description
        string objectDescription = idAndNameDict[keysList[i]];
        Console.WriteLine(objectDescription);
      }

      keyInfo = Console.ReadKey();

      if (keyInfo.Key == ConsoleKey.UpArrow)
      {
        keyIndex = (keyIndex + keysList.Count - 1) % keysList.Count;
      }
      else if (keyInfo.Key == ConsoleKey.DownArrow)
      {
        keyIndex = (keyIndex + 1) % keysList.Count;
      }
      else if (keyInfo.Key == ConsoleKey.Escape)
      {
        return null;
      }

    } while (keyInfo.Key != ConsoleKey.Enter);

    // return the selected key
    return keysList[keyIndex];
  }

  public static DateTime? GetDate()
  {
    Console.CursorVisible = true;
    int month, day, year;
    bool isValidInput = false;

    do
    {
      Console.Write("Enter the month number: ");
      string monthInput = Console.ReadLine();
      Console.Write("Enter the day of the month: ");
      string dayInput = Console.ReadLine();
      Console.Write("Enter the year: ");
      string yearInput = Console.ReadLine();

      if (int.TryParse(monthInput, out month) && int.TryParse(dayInput, out day) && int.TryParse(yearInput, out year))
      {
        try
        {
          DateTime date = new DateTime(year, month, day);
          isValidInput = true;
          Console.CursorVisible = false;
          return date;
        }
        catch (ArgumentOutOfRangeException)
        {
          DisplayMessage("(!) Invalid date. Please enter a valid date...\n\n", type: "warning");
          Utils.MessageToContinueAndClear();
          return null;
        }
      }
      else
      {
        DisplayMessage("(!) Invalid input. Please enter numeric values...\n\n", type: "warning");
        Utils.MessageToContinueAndClear();
        return null;
      }
    } while (!isValidInput);
  }
}