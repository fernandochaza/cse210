public class Profile
{
    private string _userName;
    private List<Goal> _userGoals;
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
    public void Initialize()
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

        foreach (string line in lines)
        {
            Goal goal = new Goal();
            goal.ParseGoal(line);
        }
    }

    
    public void SaveUserData()
    {

    }

    public void DisplayGoals()
    {

    }

    private void AddGoalToDatabase()
    {

    }
    
    public void DisplayTotalScore()
    {
        
    }
}