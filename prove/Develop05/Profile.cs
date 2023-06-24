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
        string[] lines = System.IO.File.ReadAllLines(_databaseFilename);

        if (lines.Length >= 1)
        {
            foreach (string line in lines)
            {
                Goal goal = new Goal();
                goal.ParseGoal(line);
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

        Console.WriteLine("\n> New Goal added to your database");
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }


    public void DisplayGoals()
    {

    }

    private void LoadGoalToProfile(Goal goal)
    {
        _userGoals.Add(goal);
    }
    
    public void DisplayTotalScore()
    {
        
    }
}