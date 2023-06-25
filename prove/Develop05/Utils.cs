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
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        return validInteger;
    }


    public static Goal CreateGoalFromInt(int goalType)
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
                Console.WriteLine("Invalid type");
                return null;
        }
    }


    public static void DisplayGoalTypes()
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
    }


    public static void DisplayText(string text)
    {
        int textLength = text.Length;

        for (int i = 0; i < textLength; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(20);
            // Console.Write("\b \b"); // Erase the character
        }
    }

}