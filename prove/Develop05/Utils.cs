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
            Console.Write(message);

            userInput = Console.ReadLine();

            // Parse the input or display an error until the input is valid
            if (int.TryParse(userInput, out validInteger))
            {
                isValidNumber = true;
            }
            else
            {
                Console.WriteLine("\n> Invalid input. Please enter a valid integer.");
            }
        }

        return validInteger;
    }


/// <summary>
/// Instantiate a Goal subclass accordingly to the given integer and return it. (1:SimpleGoal, 2:EternalGoal, 3:ChecklistGoal)
/// </summary>
/// <param name="goalType"></param>
/// <returns></returns>
    public static Goal InstantiateGoalFromInt(int goalType)
    {
        switch (goalType)
        {
            case 1:
                SimpleGoal simpleGoal = new SimpleGoal();
                return simpleGoal;
            case 2:
                EternalGoal eternalGoal = new EternalGoal();
                return eternalGoal;
            case 3:
                ChecklistGoal checklistGoal = new ChecklistGoal();
                return checklistGoal;
            default:
                Console.WriteLine("\n> Invalid type!\n");
                return null;
        }
    }


    /// <summary>
    /// Print an ordered list of the available Goal types
    /// </summary>
    public static void DisplayGoalTypes()
    {
        DisplayText("\nThe types of goals are:\n");
        DisplayText("1. Simple Goal\n");
        DisplayText("2. Eternal Goal\n");
        DisplayText("3. Checklist Goal\n");
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
            Thread.Sleep(1);
        }
    }
}