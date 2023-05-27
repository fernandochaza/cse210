/// <summary>
/// Manage scripture creation, displaying and words hiding
/// </summary>
public class Scripture
{
    private Reference _reference;
    private List<Word> _text = new List<Word>();
    private string _separator = "|";

    /// <summary>
    /// Instantiate a Scripture reading from the user's input
    /// </summary>
    public Scripture()
    {
        Console.Write("Enter the reference (e.g. Book 1:2-3): ");
        Reference reference = new Reference(Console.ReadLine());
        _reference = reference;

        Console.Write("Enter the text: ");
        string userText = Console.ReadLine();

        List<string> wordList = userText.Split(" ").ToList();

        AddWords(wordList);
    }


    /// <summary>
    /// Instantiate a new Scripture from a raw scripture formatted as "Book 1:2-3|This is the text"
    /// </summary>
    public Scripture(string rawScripture)
    {
        string[] scriptureParts = rawScripture.Split(_separator);

        Reference reference = new Reference(scriptureParts[0]);
        _reference = reference;

        List<string> wordList = scriptureParts[1].Split(" ").ToList();
        AddWords(wordList);
    }

    /// <summary>
    /// Instantiate a new Scripture given the Reference as "Book 1:2-3" and a string of text
    /// </summary>
    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        List<string> wordList = text.Split(" ").ToList();
        AddWords(wordList);
    }


    /// <summary>
    /// Create a Word instance and add it to the Scripture Text for each string in a List
    /// </summary>
    /// <param name="words">A list of strings</param>
    public void AddWords(List<string> words)
    {
        foreach (string word in words)
        {
            Word wordToAdd = new Word(word);
            _text.Add(wordToAdd);
        }
    }


    /// <summary>
    /// Get or Set the Scripture text
    /// </summary>
    public List<Word> Text
    {
        get {return _text;}
        set {_text = value;}
    }


    /// <summary>
    /// Returns the Reference of the Scripture
    /// </summary>
    /// <value>An instance of the Reference class</value>
    public Reference Reference
    {
        get {return _reference;}
    }


    /// <summary>
    /// Return a string representation of a complete scripture including its reference, a separator, and its text
    /// to be used as a line in a database
    /// </summary>
    public string SaveScripture()
    {
        return $"{_reference.ToString()}{_separator}{string.Join(" ", DisplayText())}";
    }


    /// <summary>
    /// Return a string representation of a complete scripture including its reference and its text 
    /// formatted to be displayed to the user
    /// </summary>
    public override string ToString()
    {
        List<string> displayText = new List<string>();
        foreach (Word word in _text)
        {
            displayText.Add(word.GetWord);
        }
        return $"{_reference.ToString()}\n{string.Join(" ", displayText)}";
    }


    /// <summary>
    /// Hide random words from the Scripture
    /// </summary>
    public void HideRandom()
    {
        Random random = new Random();

        // Generate random number of words to hide
        int numberOfWordsToHide = random.Next(1,4);

        // Set a counter of hidden words
        int hiddenWords = 0;

        // Check if the the program already hide the number of random words for this step and
        // if all the words in the text aren't already hidden
        while (hiddenWords < numberOfWordsToHide && CountHidden() != _text.Count)
        {
            int index;
            do
            {
                // Generate random index
                index = random.Next(_text.Count);
            } while (_text[index].Hidden);

            // Take the word from the words list and replace its value for the underscores
            _text[index].Hide();
            hiddenWords ++;
        }
        
        // Check if all the words are hidden
        if (CountHidden() == _text.Count)
        {
            Console.WriteLine("--> All the words are hidden");
        }
    }


    /// <summary>
    /// Return a string representing each Word in the Scripture Text. Includes the hidden behavior
    /// </summary>
    /// <returns>A string representing the scripture Text</returns>
    public string DisplayText()
    {
        return string.Join(" ", _text.Select(word => word.DisplayWord()));
    }


    /// <summary>
    /// Set the Hidden value to false for every Word in this Scripture instance
    /// </summary>
    public void RevealWords()
    {
        foreach (Word word in _text)
        {
            word.Show();
        }
    }

    /// <summary>
    /// Count the number of Words hidden
    /// </summary>
    /// <returns>An integer</returns>
    public int CountHidden()
    {
        int hidden = 0;
        foreach (Word word in _text)
        {
            if (word.Hidden)
            {
                hidden++;
            }
        }
        return hidden;
    }
}