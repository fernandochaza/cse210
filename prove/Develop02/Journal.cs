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

    public void LoadJournal()
    {
        string[] lines = System.IO.File.ReadAllLines("journal.txt");

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            
            DateTime _date = DateTime.Parse(parts[0]);
            string _prompt = parts[1];
            string _answer = parts[2];

            Entry newEntry = new Entry(_prompt);
            newEntry._date = _date;
            newEntry._prompt = _prompt;
            newEntry._answer = _answer;
            _entries.Add(newEntry);
        }
    }

    public void SaveJournal()
    {
        using (StreamWriter outputFile = new StreamWriter("journal.txt"))
        {
            // You can add text to the file with the WriteLine method
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry.SaveEntry()}");
            }
        }
    }

    public void AddEntryToDatabase(Entry newEntry)
    {
        using (StreamWriter outputFile = File.AppendText("journal.txt"))
        {
            outputFile.WriteLine($"{newEntry.SaveEntry()}");
        }
        Console.WriteLine("\n--> New entry added to your Journal");
        Console.Write("Press any key to continue...");
        Console.ReadLine();
    }
    
    public void DisplayJournal()
    {
        foreach(Entry entry in _entries)
        {
            Console.WriteLine(entry.ReturnEntry());
        }
    }
};