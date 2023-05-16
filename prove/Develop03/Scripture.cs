/// <summary>
/// Manage scripture creation, displaying and words hiding
/// </summary>
public class Scripture
{
    private Reference _reference;
    private List<string> _text;
    private string _separator = "|";


    /// <summary>
    /// Instantiate a new Scripture from a raw scripture formatted as "Book 1:2-3|This is the text"
    /// </summary>
    public Scripture(string rawScripture)
    {
        string[] scriptureParts = rawScripture.Split(_separator);

        Reference reference = new Reference(scriptureParts[0]);

        string text = scriptureParts[1];
        foreach (string word in text.Split(" "))
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


    // public Reference Reference
    // {
    //     get {return _reference;}
    // }


    // public List<string> Text
    // {
    //     get {return _text;}
    // }

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
    public string DisplayScripture()
    {
        return $"{_reference.ToString()} \"{string.Join(" ", _text)}\"";
    }
}
