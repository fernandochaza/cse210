using System.IO;

// Responsibilities: 
// - Store the journal's entries
// - Save the journal in a txt file
// - Load a stored txt file containing Journal entries
// - Display the journal entries to the user

/// <summary>
/// Class <c>Journal</c> get the user name, manage the journal file
/// and display the Journal to the user
/// </summary>
public class Journal
{
    public string _name;
    public List<Entry> _entries = new List<Entry>();
    public string _filename;

    public string LoadJournalFromFile()
    {
        return "";
    }

    public void SaveJournalToFile()
    {
        Console.Write("Enter the filename and extension: ");
        _filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            // You can add text to the file with the WriteLine method
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine("This will be the first line in the file.");
            }
            
            // You can use the $ and include variables just like with Console.WriteLine
            string color = "Blue";
            outputFile.WriteLine($"My favorite color is {color}");
        }

    }

    public void DisplayJournal()
    {

    }


    // {
    //     string filename;
    //     Console.Write("Enter the name of the file: ");
    //     filename = Console.ReadLine();

    //     string[] lines = File.ReadAllLines(filename);

    //     return "";

    // }

        // string filename;
        // using (StreamWriter outputFile = new StreamWriter(filename))
        // outputFile.
}