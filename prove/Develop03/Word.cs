public class Word
{
    private string _word;
    private bool _hidden;

    public Word(string word)
    {
        _word = word;
        _hidden = false;
    }


    public string GetWord
    {
        get {return _word;}
    }


    public bool Hidden
    {
        get {return _hidden;}
    }


    public void Hide()
    {
        _hidden = true;
    }


    public void Show()
    {
        _hidden = false;
    }

/// <summary>
/// Return a string representing a Word. If the Word is set to Hidden, returns underscores.
/// </summary>
/// <returns>A string representation of the word OR a string of underscores</returns>
    public string DisplayWord()
    {
        // Check is the word is not Hidden to return the actual word
        if (!_hidden)
        {
            return _word;
        }
        else
        {
            // Generate a string of "n" underscores, where "n" is the length of the word
            string underscores = new String('_', _word.Length);
            return underscores;
        }
    }
}