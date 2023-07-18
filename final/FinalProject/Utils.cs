using ConsoleTables;

public static class Utils
{
  /// <summary>
  /// Display a prompt and validate an user integer input
  /// </summary>
  /// <param name="message">The prompt displayed to the user to ask for an integer input</param>
  /// <returns>A validated integer</returns>
  public static int? GetUserInt(string prompt)
  {
    ConsoleKeyInfo keyInfo;

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

      keyInfo = Console.ReadKey();

      if (keyInfo.Key == ConsoleKey.Escape)
        {
          return null;
        }

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
    Console.ForegroundColor = ConsoleColor.Green;
    Console.CursorVisible = false;
    Utils.TextAnimation("\n> Press Enter to continue...");
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
}