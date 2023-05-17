/// <summary>
/// Manage scripture creation, displaying and words hiding
/// </summary>
public class Scripture
{
    private MemorizeManager _memorizeManager = new MemorizeManager();
    private Reference _reference;
    private List<string> _text = new List<string>();
    private string _separator = "|";

    /// <summary>
    /// Instantiate a Scripture reading from the user's input
    /// </summary>
    public Scripture()
    {
        Console.Write("Enter the reference (e.g. Book 1:2-3): ");
        Reference reference = new Reference(Console.ReadLine());

        Console.Write("Enter the text: ");
        string text = Console.ReadLine();

        _reference = reference;
        _text = text.Split(" ").ToList();
    }


    /// <summary>
    /// Instantiate a new Scripture from a raw scripture formatted as "Book 1:2-3|This is the text"
    /// </summary>
    public Scripture(string rawScripture)
    {
        string[] scriptureParts = rawScripture.Split(_separator);

        Reference reference = new Reference(scriptureParts[0]);

        string[] text = scriptureParts[1].Split(" ");
        foreach (string word in text)
        {
            _text.Add(word);
        }
        _reference = reference;
    }

    /// <summary>
    /// Instantiate a new Scripture given the Reference as "Book 1:2-3" and a string of text
    /// </summary>
    public Scripture(Reference reference, string text)
    {
        foreach (string word in text.Split(" "))
        {
            _text.Add(word);
        }
        _reference = reference;
    }


    /// <summary>
    /// Get the MemorizeManager instance for this Scripture
    /// </summary>
    /// <value>An instance of the MemorizeManager class</value>
    public MemorizeManager MemorizeManager
    {
        get {return _memorizeManager;}
    }


    /// <summary>
    /// Get or Set the Scripture text
    /// </summary>
    public List<string> Text
    {
        get {return _text;}
        set {_text = value;}
    }


    /// <summary>
    /// Return a string representation of the Scripture text
    /// </summary>
    public string JoinedText
    {
        get {return string.Join(" ", _text);}
    }


    /// <summary>
    /// Get the Reference instance for this Scripture
    /// </summary>
    /// <value>An instance of the Reference class</value>
    public string Reference
    {
        get {return _reference.ToString();}
    }

    /// <summary>
    /// Return a string representation of a complete scripture including its reference, a separator, and its text
    /// to be used as a line in a database
    /// </summary>
    public string SaveScripture()
    {
        return $"{_reference.ToString()}{_separator}{string.Join(" ", _text)}";
    }

    /// <summary>
    /// Return a string representation of a complete scripture including its reference and its text 
    /// formatted to be displayed to the user
    /// </summary>
    public override string ToString()
    {
        return $"{_reference.ToString()} \"{string.Join(" ", _text)}\"";
    }

    /// <summary>
    /// Print the scripture Reference and call the Memorize method
    /// </summary>
    public void MemorizeScripture()
    {
        Console.WriteLine(_reference.ToString());
        _memorizeManager.Memorize(_text);    
    }
}