/// <summary>
/// Represent a reference for a scripture
/// </summary>
public class Reference
{
    private string _book;
    private int _chapter;
    private int _initialVerse;
    private int _endingVerse;

    /// <summary>
    /// Instantiate a new Reference from a raw string reference formatted as "Book 1:2-3"
    /// where the ending verse is optional
    /// </summary>
    public Reference(string rawReference)
    {
        // Define the string separators
        string bookAndPassageSeparator = " ";
        string chapterAndVerseSeparator = ":";
        string versesSeparator = "-";
        int endingVerse = 0;
        int initialVerse = 0;

        // Divide the reference into Book and Passage
        string[] referenceParts = rawReference.Split(bookAndPassageSeparator);
        string book = referenceParts[0];
        
        // Divide the passage into Chapter and Verse/s
        string[] passage = referenceParts[1].Split(chapterAndVerseSeparator);
        int chapter = int.Parse(passage[0]);

        // Check if the passage contains more than a single verse
        if (passage[1].Contains(versesSeparator))
        {
            // Divide initial and ending verses
            string[] verses = passage[1].Split(versesSeparator);
            initialVerse = int.Parse(verses[0]);
            endingVerse = int.Parse(verses[1]);
        }
        else
        {
            initialVerse = int.Parse(passage[1]);
        }

        _book = book;
        _chapter = chapter;
        _initialVerse = initialVerse;

        if (endingVerse != 0)
        {
            _endingVerse = endingVerse;
        }
    }

    /// <summary>
    /// Instantiate a new Reference given the book name, chapter, and single verse
    /// </summary>
    public Reference(string book, int chapter, int InitialVerse)
    {
        _book = "book";
        _chapter = chapter;
        _initialVerse = InitialVerse;
    }


    /// <summary>
    /// Instantiate a new Reference given the book name, chapter, initial verse, and ending verse
    /// </summary>    
    public Reference(string book, int chapter, int InitialVerse, int endingVerse)
    {
        _book = "book";
        _chapter = chapter;
        _initialVerse = InitialVerse;
        _endingVerse = endingVerse;
    }


    /// <summary>
    /// Return a string representation of the Reference
    /// </summary>
    public override string ToString()
    {
        string referenceString = $"{_book} {_chapter}:{_initialVerse}";

        if (_endingVerse != 0)
        {
            referenceString += $"-{_endingVerse}";
        }

        return referenceString;
    }
}