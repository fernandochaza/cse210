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
      Utils.TextAnimation(prompt);

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
  public static void TextAnimation(string text)
  {
    int textLength = text.Length;

    for (int i = 0; i < textLength; i++)
    {
      Console.Write(text[i]);
      Thread.Sleep(0);
    }
  }

  /// <summary>
  /// Allow the user to decide when to continue by pressing a key before cleaning the console
  /// </summary>
  public static void MessageToContinueAndClear()
  {
    Console.CursorVisible = false;
    Utils.TextAnimation("\n> Press Enter to continue...");
    Console.ReadLine();
    Console.Clear();
  }

  public static int? GetSelectedKeyFromDict(string prompt, Dictionary<int, string> idsAndDescriptionDict)
  {
    ConsoleKeyInfo keyInfo;

    // Generate a List of the dictionary keys that represents the object ID
    List<int> keysList = idsAndDescriptionDict.Keys.ToList();

    // This contain the user selected item as an index of the keysList variable
    int keyIndex = 0;

    do
    {
      Console.Clear();
      Utils.TextAnimation($"{prompt}\n\n");

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
        string objectDescription = idsAndDescriptionDict[keysList[i]];
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

  public static string GetSelectedOption(string prompt, List<string> options, ConsoleTable table = null)
  {
    ConsoleKeyInfo keyInfo;
    int selectedIndex = 0;

    Console.CursorVisible = false;

    do
    {
      Console.Clear();

      if (table != null)
      {
        table.Write(Format.Minimal);
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

  // public static string GetSelectedString(string prompt, List<string> options)
  // {
  //   ConsoleKeyInfo keyInfo;
  //   int selectedIndex = 0;

  //   do
  //   {
  //     Console.Clear();
  //     Console.WriteLine($"{prompt}\n");

  //     for (int i = 0; i < options.Count; i++)
  //     {
  //       if (i == selectedIndex)
  //       {
  //         Console.Write("-> ");
  //       }
  //       else
  //       {
  //         Console.Write("   ");
  //       }

  //       // Display the option text
  //       string optionText = options[i];
  //       Console.WriteLine(optionText);
  //     }

  //     keyInfo = Console.ReadKey();

  //     if (keyInfo.Key == ConsoleKey.UpArrow)
  //     {
  //       selectedIndex = (selectedIndex + options.Count - 1) % options.Count;
  //     }
  //     else if (keyInfo.Key == ConsoleKey.DownArrow)
  //     {
  //       selectedIndex = (selectedIndex + 1) % options.Count;
  //     }
  //     else if (keyInfo.Key == ConsoleKey.Escape)
  //     {
  //       return null;
  //     }

  //   } while (keyInfo.Key != ConsoleKey.Enter);

  //   // return the selected string
  //   return options[selectedIndex];
  // }

  // public static void DisplayTable(List<string> headers, List<List<string>> data)
  // {
  //   var table = new ConsoleTable(headers.ToArray());

  //   for (int i = 0; i < data.Count; i++)
  //   {
  //     table.AddRow(data[i].ToArray());
  //   }

  //   table.Write();
  // }
}