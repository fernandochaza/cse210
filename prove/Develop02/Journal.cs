using System.IO;
using System.Globalization;

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

    public void LoadJournal()
    {
        string[] lines = System.IO.File.ReadAllLines("journal.txt");

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            
            DateTime _date = DateTime.Parse(parts[0]);
            DateTime _time = DateTime.Parse(parts[1]);
            string _prompt = parts[2];
            string _answer = parts[3];

            Entry newEntry = new Entry();
            newEntry._date = _date;
            newEntry._time = _time;
            newEntry._prompt = _prompt;
            newEntry._answer = _answer;
            _entries.Add(newEntry);
        }
    }

    /// <summary>
    /// Creates a new database for the Journal
    /// </summary>
    public void SaveJournal()
    {
        using (StreamWriter outputFile = new StreamWriter("journal.txt"))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry.SaveEntry()}");
            }
        }
    }

    /// <summary>
    /// Add a new line to the Journal database with the new entry
    /// </summary>
    /// <param name="newEntry">An Entry instance</param>
    public void AddEntryToDatabase(Entry newEntry)
    {
        using (StreamWriter outputFile = File.AppendText("journal.txt"))
        {
            outputFile.WriteLine($"{newEntry.SaveEntry()}");
        }
        Console.WriteLine("\n> New entry added to your Journal");
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }
    
    /// <summary>
    /// Display the complete Journal Entries
    /// </summary>
    public void DisplayJournal()
    {
        foreach(Entry entry in _entries)
        {
            Console.Write(entry.ReturnEntry());
        }
    }
};