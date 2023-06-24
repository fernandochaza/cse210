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


    protected string Type
    {
        set {_type = value;}
    }
    
    
    protected string Name
    {
        set {_name = value;}
    }
    
    protected string Description
    {
        set {_shortDescription = value;}
    }
    
    protected int Points
    {
        set {_points = value;}
    }
    
    protected bool Completed
    {
        set {_isCompleted = value;}
    }
    

    // public Goal SetGoal(int type)
    // {
    //     Goal goal = SetGoalType(type);
    //     return goal;
    // }

    public void CreateGoal()
    {
        DisplayGoalTypes();

        // Get and validate user choice
        int typeSelected = GetUserInt("Which type of goal would you like to create? ");

        Goal goal = SetGoalType(typeSelected);

        if (goal != null)
        {
            Console.Write("What is the name of your goal? ");
            goal._name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            goal._shortDescription = Console.ReadLine();
            goal._points = GetUserInt("What is the amount of points associated with this goal? ");
        }
        
    }


    public void ParseGoal(string line)
    {
        string[] parts = line.Split("|");
        int type = int.Parse(parts[0]);
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool isCompleted = bool.Parse(parts[4]);
        if (parts.Length > 5)
        {
            int currentRepetitions = int.Parse(parts[5]);
            int repetitionsToComplete = int.Parse(parts[6]);
            int bonusPoints = int.Parse(parts[7]);
        }

        Goal goal = SetGoalType(type);
        goal.Name = name;
        goal.Description = description;
        goal.Points = points;
        goal.Completed = isCompleted;
    }

    /// <summary>
    /// Display a prompt and validate a user integer input 
    /// </summary>
    /// <param name="message">The prompt displayed to the user to ask for an integer input</param>
    /// <returns>A valid integer</returns>
    public int GetUserInt(string message)
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
    public Goal SetGoalType(int type)
    {
        switch (type)
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

    public void DisplayGoalTypes()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
    }
}