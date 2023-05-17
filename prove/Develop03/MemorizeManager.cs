/// <summary>
/// Take a string of text and randomly hide words from it
/// to help the user memorize the text
/// </summary>
public class MemorizeManager
{
    private Random _random = new Random();
    private List<int> _excludedIndexes = new List<int>();


    /// <summary>
    /// Hides random words from a given text
    /// </summary>
    /// <param name="words">An array of ordered strings representing a text</param>
    public void Memorize(List<string> words)
    {
        // Choose a random number of words between 1 and 4 to hide
        int numberOfWords = _random.Next(4);

        int index;
        int counter = 0;
        
        do
        {
            // Choose a random integer to use as the array's index to hide the word
            index = _random.Next(words.Count);

            // Check if the index was already selected
            if (!_excludedIndexes.Contains(index))
            {
                // Add the current index to the exclusion list
                _excludedIndexes.Add(index);
                // Generate a string of "n" underscores, where "n" is the length of the word to hide
                string underscores = new String('_', words[index].Length);
                // Take the word from the words list and replace its value for the underscores
                words[index] = underscores;

                counter ++;
            }
        } while (counter <= numberOfWords && _excludedIndexes.Count < words.Count);

        if (_excludedIndexes.Count == words.Count)
        {
            Console.WriteLine("All the words were hidden");
        }
    }


    /// <summary>
    /// Get the quantity of excluded words for the current instance
    /// </summary>
    /// <value>An integer that represents the number of words hidden</value>
    public int ExcludedQuantity
    {
        get {return _excludedIndexes.Count;}
    }
}