public class Profile
{
    private string _userName;
    private List<Goal> _userGoals = new List<Goal>();
    private string _databaseFilename = "goals-data.txt";


    public Profile()
    {

    }


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
    /// Read the database file and create the necessary scriptures
    /// </summary>
    public void LoadUserData()
    {
        string[] databaseLines = System.IO.File.ReadAllLines(_databaseFilename);

        if (databaseLines.Length >= 1)
        {
            foreach (string stringGoal in databaseLines)
            {
                Goal goal = new Goal(stringGoal);
                LoadGoalToProfile(goal);
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
        Utils.DisplayText("Press Enter to continue...");
        Console.ReadLine();
    }


    /// <summary>
    /// Display the statistics of every goal in the user database
    /// </summary>
    public void DisplayGoalsData()
    {
        foreach (Goal goal in _userGoals)
        {
            Console.WriteLine(goal.GetGoalStatus());
        }
    }


    /// <summary>
    /// Add a new goal to the user Profile
    /// </summary>
    /// <param name="goal"></param>
    private void LoadGoalToProfile(Goal goal)
    {
        _userGoals.Add(goal);
    }
    

    public void DisplayTotalScore()
    {
        
    }
}