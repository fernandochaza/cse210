public class Profile
{
    private string _userName;
    private List<Goal> _userGoals = new List<Goal>();
    private string _databaseFilename = "goals-data.txt";


    public Profile()
    {

    }


    /// <summary>
    /// Get/Set User Name
    /// </summary>
    /// <value></value>
    public string UserName
    {
        get {return _userName;}
        set {_userName = value;}
    }

    
    /// <summary>
    /// Check the existence of the database file. Create a new one if it doesn't exists
    /// </summary>
    public void InitializeDatabase()
    {
        // If the database file doesn't exists, create one
        if (!File.Exists(_databaseFilename))
        {
            using (StreamWriter file = File.CreateText(_databaseFilename))
            {
                // Create an empty file
                Console.WriteLine("(!) New database created in the main program folder (goals-data.txt)");
            }
        }
        else
        {
            LoadUserData();
            Console.WriteLine("(!) Reading data from the existing database (goals-data.txt)");
        }
    }


    /// <summary>
    /// Read the database file and load the user Goals
    /// </summary>
    public void LoadUserData()
    {
        string[] databaseLines = System.IO.File.ReadAllLines(_databaseFilename);

        if (databaseLines.Length >= 1)
        {
            foreach (string stringGoal in databaseLines)
            {
                string[] parts = stringGoal.Split("|");
                int goalType = int.Parse(parts[0]);
                Goal goal = CreateGoal(goalType, stringGoal);
                _userGoals.Add(goal);
            }  
        }
    }

    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="goal"></param>
    public void AddGoalToDatabase(Goal goal)
    {
        // Add new line in database to represent the new Goal
        using (StreamWriter outputFile = File.AppendText(_databaseFilename))
        {
            outputFile.WriteLine($"{goal.GetStringRepresentation()}");
        }

        // Add the goal to the user Profile list of Goals
        _userGoals.Add(goal);

        Utils.DisplayText("\n(!) New Goal added to your database");
        Utils.MessageToContinueAndClear();
    }


    private void UpdateDatabase()
    {
        // Add new line in database to represent the new Goal
        using (StreamWriter outputFile = File.CreateText(_databaseFilename))
        {
            foreach (Goal goal in _userGoals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }


    /// <summary>
    /// Display the statistics of every goal in the user database
    /// </summary>
    public void DisplayGoalsData()
    {
        Console.Clear();

        DisplayCompletedGoals();
        DisplayAvailableGoals();

        Utils.MessageToContinueAndClear();
    }


    /// <summary>
    /// Create the required Goal type and and populate its variables with the given string that represents the Goal data (1:SimpleGoal, 2:EternalGoal, 3:ChecklistGoal)
    /// </summary>
    /// <param name="goalType">An integer representing the Goal type</param>
    /// <param name="stringGoal">A string representation of the Goal data</param>
    /// <returns>A new instance of the Goal subclass</returns>
    private static Goal CreateGoal(int goalType, string stringGoal)
    {
        switch (goalType)
        {
            case 1:
                SimpleGoal simpleGoal = new SimpleGoal(stringGoal);
                return simpleGoal;
            case 2:
                EternalGoal eternalGoal = new EternalGoal(stringGoal);
                return eternalGoal;
            case 3:
                ChecklistGoal checklistGoal = new ChecklistGoal(stringGoal);
                return checklistGoal;
            default:
                Console.WriteLine("\n(!) Invalid type!\n");
                return null;
        }
    }


    /// <summary>
    /// Instantiate a Goal subclass accordingly to the given integer and return it. (1:SimpleGoal, 2:EternalGoal, 3:ChecklistGoal)
    /// </summary>
    /// <param name="goalType"></param>
    /// <returns>A new instance of the Goal subclass</returns>
    public static Goal CreateEmptyGoal(int goalType)
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
                Console.WriteLine("\n(!) Invalid type!\n");
                return null;
        }
    }


    /// <summary>
    /// Print an ordered list of the available Goal types
    /// </summary>
    public static void DisplayGoalTypes()
    {
        Utils.DisplayText("\nThe types of goals are:\n");
        Utils.DisplayText("1. Simple Goal\n");
        Utils.DisplayText("2. Eternal Goal\n");
        Utils.DisplayText("3. Checklist Goal\n");
    }


    /// <summary>
    /// Display the user goals with status "Completed"
    /// </summary>
    private void DisplayCompletedGoals()
    {
        Utils.DisplayText("\nCompleted Goals:\n");
        foreach (Goal goal in _userGoals)
        {
            if (goal.IsCompleted)
            {
                Utils.DisplayText($"{goal.GetGoalStatus()}\n");
            }
        }
        Console.WriteLine();
    }


    /// <summary>
    /// Display the user goals with status NOT "Completed"
    /// </summary>
    private void DisplayAvailableGoals()
    {
        Utils.DisplayText("\nAvailable Goals:\n");
        foreach (Goal goal in _userGoals)
        {
            if (!goal.IsCompleted)
            {
                Utils.DisplayText($"{goal.GetGoalStatus()}\n");
            }
        }
    }


    /// <summary>
    /// Get the user goals with status NOT completed
    /// </summary>
    private Dictionary<int, int> GetAvailableGoals()
    {
        int goalIndex = 0;
        int listIndex = 1;

        // Create new dictionary to store the available Goals with their indexes
        Dictionary<int, int> availableGoals = new Dictionary<int, int>();

        // Iterate through all the user Goals
        foreach (Goal goal in _userGoals)
        {
            // Get only the Goals available to complete
            if (!goal.IsCompleted)
            {
                // Add the list number and the Goal index into the dictionary
                availableGoals.Add(listIndex, goalIndex);

                listIndex++;
            }
            goalIndex++;
        }

        return availableGoals;
    }


    /// <summary>
    /// Add a new event to an user selected's available Goal
    /// </summary>
    public void AddEvent()
    {
        Dictionary<int, int> availableGoals = GetAvailableGoals();
        int goalToComplete = 0;

        do
        {
            // Display the available Goals
            Console.Clear();
            Console.WriteLine("\nAvailable Goals:");
            foreach (KeyValuePair<int, int> goal in availableGoals)
            {
                int goalIndex = goal.Value;
                Utils.DisplayText($"{goal.Key} - {_userGoals[goalIndex].GetGoalStatus()}\n");
            }

            // Get the user selected goal's list number.
            goalToComplete = Utils.GetUserInt("\n> For which goal do you want to record and event? ");
            Console.WriteLine($"AVAILABLE GOALS: {availableGoals.Count}");
            if (goalToComplete < 0 || goalToComplete > availableGoals.Count)
            {
                Utils.DisplayText("\n(!) That number doesn't match with an available Goal. Try Again...\n");
                Utils.MessageToContinueAndClear();
            }
            // Check that the user input matches an available goal
        } while (goalToComplete < 0 || goalToComplete > availableGoals.Count);

        // Use the list number to get the Goal index from the dictionary
        int goalToCompleteIndex = availableGoals[goalToComplete];

        // Use the index to mark the Goal Completed OR add a new repetition to it
        _userGoals[goalToCompleteIndex].NewEvent();
        UpdateDatabase();

        Utils.DisplayText("(!) The event was successfully recorded!\n");
        Utils.MessageToContinueAndClear();
    }


    /// <summary>
    /// Get the user total Score from its completed Goals
    /// </summary>
    /// <returns></returns>
    public int GetTotalScore()
    {
        int totalScore = 0;

        foreach (Goal goal in _userGoals)
        {
            int goalScore = goal.GetScore();
            totalScore += goalScore;   
        }

        return totalScore;
    }


    public int GetAvailableGoalsQuantity()
    {
        int quantity = 0;
        foreach (Goal goal in _userGoals)
        {
            if (!goal.IsCompleted)
            {
                quantity++;
            }
        }
        return quantity;
    }
}