public static class Utils
{
    /// <summary>
    /// Display a prompt and validate a user integer input 
    /// </summary>
    /// <param name="message">The prompt displayed to the user to ask for an integer input</param>
    /// <returns>A valid integer</returns>
    public static int GetUserInt(string message)
    {
        string userInput;
        int validInteger = 0;
        bool isValidNumber = false;

        while (!isValidNumber)
        {
            // Display the given prompt
            Utils.DisplayText(message);

            userInput = Console.ReadLine();

            // Parse the input or display an error until the input is valid
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
    /// Create a text typing animation from a given text
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

    public static void MessageToContinueAndClear()
    {
        Utils.DisplayText("\n> Press Enter to continue...");
        Console.ReadLine();
        Console.Clear();
    }
}