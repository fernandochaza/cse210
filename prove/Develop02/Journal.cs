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

    public void LoadJournalFromFile()
    {
        Console.Write("Enter the filename and extension: ");
        _filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(_filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            
            DateTime _date = DateTime.Parse(parts[0]);
            string _prompt = parts[1];
            string _answer = parts[2];

            Entry newEntry = new Entry();
            newEntry._date = _date;
            newEntry._prompt = _prompt;
            newEntry._answer = _answer;
            _entries.Add(newEntry);
        }
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
                outputFile.WriteLine($"{entry.SaveEntry()}");
            }
        }

    }

    public void DisplayJournal()
    {
        foreach(Entry entry in _entries)
        {
            Console.WriteLine(entry.ReturnEntry());
        }
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