using System;

class Program
{
    static void Main(string[] args)
    {
        // Instantiate a new Scriptures database
        MyScriptures myScriptures = new MyScriptures();
        myScriptures.Initialize();

        // Instantiate a new Menu
        Menu mainMenu = new Menu();

        // Display welcome message
        mainMenu.DisplayWelcome("Fernando");

        // Variable to store the user option choice
        string selectedOption;
        
        do
        {
            // Display the menu options
            mainMenu.DisplayOptions();

            // Read the user choice
            selectedOption = Console.ReadLine();

            // Handle each menu option
            switch (selectedOption)
            {
                case "1":
                    myScriptures.DisplayScriptures();
                    break;
                case "2":
                    Scripture newScripture = new Scripture();
                    myScriptures.AddScriptureToDatabase(newScripture);
                    break;
                case "3":
                    myScriptures.DisplayScriptures();
                    Console.Write("Select the number of scripture to memorize: ");
                    int choice = int.Parse(Console.ReadLine());
                    Scripture UserScripture = myScriptures.GetScripture(choice);
                    UserScripture.MemorizeScripture();
                    Console.WriteLine(UserScripture.JoinedText);
                    break;
            }
        } while (selectedOption != "4");

    }
}