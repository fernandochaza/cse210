public class Goal
{
    protected string _type;
    protected string _name;
    protected string _shortDescription;
    protected int _points;
    protected bool _isCompleted;

    public Goal()
    {
    }
    
    public static Goal CreateGoal()
    {
        DisplayGoalTypes();

        // Get and validate user choice
        int typeSelected = GetUserInt("Which type of goal would you like to create? ");

        // 
        Goal goal = SetGoalType(typeSelected);

        if (goal != null)
        {
            Console.Write("What is the name of your goal? ");
            goal._name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            goal._shortDescription = Console.ReadLine();
            goal._points = GetUserInt("What is the amount of points associated with this goal? ");
        }
        
        return goal;
    }

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


    /// <summary>
    /// Create an instance of a determined Goal subclass given an integer option
    /// </summary>
    /// <param name="type">An integer that represent the Goal subclass. 
    /// (Options: 1=SimpleGoal, 2=EternalGoal, 3=ChecklistGoal)</param>
    /// <returns>A new instance of the required Goal subclass OR -null- if the type is incorrect</returns>
    public static Goal SetGoalType(int type)
    {
        switch (type)
        {
            case 1:
                return new SimpleGoal();
            case 2:
                return new EternalGoal();
            case 3:
                return new ChecklistGoal();
            default:
                Console.WriteLine("Invalid type");
                return null;
        }
    }

    public virtual void MarkCompleted()
    {

    }

    public virtual void DisplayGoal()
    {

    }

    /// <summary>
    /// Generate a one-line string to represent the Goal with it's values separated by a pipe symbol "|".
    /// </summary>
    /// <returns>A one line string</returns>
    public virtual string GetStringRepresentation()
    {
        return $"{_type}|{_name}|{_shortDescription}|{_points}|{_isCompleted}";
    }

    public static void DisplayGoalTypes()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
    }
}