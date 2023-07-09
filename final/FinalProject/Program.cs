using System;

class Program
{
  static void Main(string[] args)
  {
    // Instantiate a new Profile
    Profile userProfile = new Profile();

    userProfile.DeserializeUserData();

    // Instantiate a new Menu
    Menu.DisplayWelcome();

  }

  private static int HandleOptions(List<string> options)
  {
    int selectedIndex = 0;
    ConsoleKeyInfo keyInfo;

    Utils.DisplayText("Select an option:\n");

    do
    {
      for (int i = 0; i < options.Count; i++)
      {
          if (i == selectedIndex)
              Console.Write("-> ");
          else
              Console.Write("   ");

          Utils.DisplayText(options[i]);
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
