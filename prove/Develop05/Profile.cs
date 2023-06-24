public class Profile
{
    private List<Goal> _userGoals;
    private string _databaseFilename = "goals-data.txt";

    public Profile()
    {

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
            string[] parts = line.Split("|");
            string type = parts[0];
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