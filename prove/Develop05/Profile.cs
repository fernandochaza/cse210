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
                Goal goal = new Goal(stringGoal);
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
    }


    /// <summary>
    /// Display the statistics of every goal in the user database
    /// </summary>
    public void DisplayGoalsData()
    {
        DisplayCompletedGoals();
        DisplayAvailableGoals();
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
        Utils.DisplayText("\nThe types of goals are:\n");
        Utils.DisplayText("1. Simple Goal\n");
        Utils.DisplayText("2. Eternal Goal\n");
        Utils.DisplayText("3. Checklist Goal\n");
    }


    public void DisplayCompletedGoals()
    {
        Console.WriteLine("\nCompleted Goals:");
        foreach (Goal goal in _userGoals)
        {
            if (goal.IsCompleted)
            {
                goal.GetGoalStatus();
            }
        }
    }


    public void DisplayAvailableGoals()
    {
        Console.WriteLine("\nAvailable Goals:");
        foreach (Goal goal in _userGoals)
        {
            if (!goal.IsCompleted)
            {
                goal.GetGoalStatus();
            }
        }
    }


    public int GetTotalScore()
    {
        int totalScore = 0;

        foreach (Goal goal in _userGoals)
        {

            
        }

        return totalScore;
    }
}