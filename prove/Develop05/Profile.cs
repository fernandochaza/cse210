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
                Console.WriteLine("> New database created");
            }
        }
        else
        {
            LoadUserData();
            Console.WriteLine("> Working from the existing database\n");
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

        Utils.DisplayText("\n> New Goal added to your database");
        Utils.DisplayText("\n> Press Enter to continue...");
        Console.ReadLine();
        Console.Clear();
    }


    /// <summary>
    /// Display the statistics of every goal in the user database
    /// </summary>
    public void DisplayGoalsData()
    {
        DisplayCompletedGoals();
        DisplayAvailableGoals();
        Utils.DisplayText("\n> Press Enter to continue...");
        Console.ReadLine();
        Console.Clear();
    }


    /// <summary>
    /// Create the required Goal type and and populate its variables from a string representation of Goal data (1:SimpleGoal, 2:EternalGoal, 3:ChecklistGoal)
    /// </summary>
    /// <param name="goalType">An integer representing the Goal type</param>
    /// <param name="stringGoal">A string representation of the Goal data</param>
    /// <returns>A new instance of the Goal subclass</returns>
    public static Goal CreateGoal(int goalType, string stringGoal)
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
                Console.WriteLine("\n> Invalid type!\n");
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
                Console.WriteLine("\n> Invalid type!\n");
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
    public void DisplayCompletedGoals()
    {
        Console.WriteLine("\nCompleted Goals:");
        foreach (Goal goal in _userGoals)
        {
            if (goal.IsCompleted)
            {
                Utils.DisplayText($"{goal.GetGoalStatus()}\n");
            }
        }
    }


    /// <summary>
    /// Display the user goals with status NOT completed
    /// </summary>
    public void DisplayAvailableGoals()
    {
        Console.WriteLine("\nAvailable Goals:");
        foreach (Goal goal in _userGoals)
        {
            if (!goal.IsCompleted)
            {
                Utils.DisplayText($"{goal.GetGoalStatus()}\n");
            }
        }
    }


    /// <summary>
    /// Display an ordered list of the user goals with status NOT completed
    /// </summary>
    public void DisplayGoalsToComplete()
    {
        List<Goal> availableGoals = new List<Goal>();
        foreach (Goal goal in _userGoals)
        {
            if (!goal.IsCompleted)
            {
                availableGoals.Add(goal);
            }
        }

        int goalsQuantity = availableGoals.Count;

        Console.WriteLine("\nAvailable Goals:");
        for (int i = 0; i < goalsQuantity; i++)
        {
            string goalStatus = availableGoals[i].GetGoalStatus();
            Utils.DisplayText($"{i+1} - {goalStatus}\n");
        }
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
}