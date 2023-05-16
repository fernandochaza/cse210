using System;

/// <summary>
/// Manage a scriptures database
/// </summary>
public class MyScriptures
{
    private List<Scripture> _scriptures;
    private string _database = "scriptures.txt";


    /// <summary>
    /// Check the existence of the database file. Create a new one if it doesn't exists
    /// </summary>
    public void Initialize()
    {
        // If the database file doesn't exists, create one
        if (!File.Exists(_database))
        {
            SaveScriptures();
        }
    }


    /// <summary>
    /// Read the database file and create the necessary scriptures
    /// </summary>
    public void LoadScriptures()
    {
        string[] lines = System.IO.File.ReadAllLines(_database);

        foreach (string line in lines)
        {
            Scripture newScripture = new Scripture(line);
            _scriptures.Add(newScripture);
        }
    }


    /// <summary>
    /// Creates a new database for the scriptures
    /// </summary>
    public void SaveScriptures()
    {
        using (StreamWriter outputFile = new StreamWriter(_database))
        {
            foreach (Scripture scripture in _scriptures)
            {
                outputFile.WriteLine($"{scripture.SaveScripture()}");
            }
        }
    }


    /// <summary>
    /// Add a new line to the database that represents a scripture
    /// </summary>
    /// <param name="newScripture">An Entry instance</param>
    public void AddScriptureToDatabase(Scripture newScripture)
    {
        using (StreamWriter outputFile = File.AppendText(_database))
        {
            outputFile.WriteLine($"{newScripture.SaveScripture()}");
        }
        Console.WriteLine("\n> New entry added to your Journal");
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }
    

    /// <summary>
    /// Display the complete list of scriptures from the database
    /// </summary>
    public void DisplayScriptures()
    {
        foreach(Scripture scripture in _scriptures)
        {
            Console.Write(scripture.ToString());
        }
    }
}