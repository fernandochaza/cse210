public class Profile
{
  private string _databaseFilename = "DATABASE_NAME";

  //private Panner _planner;

  public Profile() { }

  /// <summary>
  /// Check the existence of the database file. Create a new one if it doesn't exists
  /// </summary>
  public void InitializeDatabase()
  {
    // If the database file doesn't exists, create one
    if (!File.Exists(_databaseFilename))
    {
      // Code to create a JSON file containing the user data

      Console.WriteLine(
          $"(!) New database created in the main program folder ({_databaseFilename})"
      );
    }
    else
    {
      // Code to load the existing data in the database file

      // LoadUserData();

      Console.WriteLine("(!) Reading data from the existing database (goals-data.txt)");
    }
  }
}
