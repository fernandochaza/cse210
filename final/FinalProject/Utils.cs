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
            Thread.Sleep(2);
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
}