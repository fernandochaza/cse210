public static class Utils
{
  /// <summary>
  /// Display a prompt and validate an user integer input
  /// </summary>
  /// <param name="message">The prompt displayed to the user to ask for an integer input</param>
  /// <returns>A validated integer</returns>
  public static int GetUserInt(string prompt)
  {
    string userInput;
    int validInteger = 0;
    bool isValidNumber = false;

    // Run this until the user input is valid
    while (!isValidNumber)
    {
      // Display the given prompt
      Utils.DisplayText(prompt);

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

    return validInteger;
  }

  /// <summary>
  /// Create a text typing animation from a given text to give the user a better sense of
  /// what is being printed in the console
  /// </summary>
  /// <param name="text">The text to be displayed</param>
  public static void DisplayText(string text)
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
    Utils.DisplayText("\n> Press Any Key to continue...");
    Console.ReadLine();
    Console.Clear();
  }

  public static int HandleOptions(Dictionary<int, string> options)
  {
    ConsoleKeyInfo keyInfo;

    int[] keys = options.Keys.ToArray();
    int selectedIndex = keys[0];

    Console.WriteLine("Select an option:\n");

    do
    {
      Console.Clear();
      foreach (int key in keys)
      {
          if (key == selectedIndex)
              Console.Write("-> ");
          else
              Console.Write("   ");

          Console.WriteLine(options[key]);
      }

      keyInfo = Console.ReadKey();

      if (keyInfo.Key == ConsoleKey.UpArrow)
      {
          selectedIndex = Math.Max(0, selectedIndex - 1);
      }
      else if (keyInfo.Key == ConsoleKey.DownArrow)
      {
          selectedIndex = Math.Min(options.Count - 1, selectedIndex + 1);
      }

    } while (keyInfo.Key != ConsoleKey.Enter || selectedIndex == options.Count - 1);


    // Procesar la opción seleccionada (options[selectedIndex])
    return selectedIndex;
  }

}
