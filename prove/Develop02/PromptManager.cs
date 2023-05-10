/// <summary> Manage the application prompts
/// <list type="bullet">
/// <item>
/// </item>
/// <item>
/// Load prompts from a txt file
/// </item>
/// <item>
/// Save user's custom prompts in the file
/// </item>
/// <item>
/// Generate a random prompt
/// </item>
/// </list>
/// </summary>
public class PromptManager
{
    public Dictionary<int, string> _prompts = new Dictionary<int, string>();

    public PromptManager()
    {
        _prompts = new Dictionary<int, string>();

        // Load prompts from a txt file
        string[] lines = System.IO.File.ReadAllLines("prompts.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            _prompts.Add(int.Parse(parts[0]), parts[1]);
        }
    }

    /// <summary>
    /// Select a random prompt from a predefined array of prompts
    /// </summary>
    /// <returns>A random prompt</returns>
    public string ReturnRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    /// <summary>
    /// Add a custom prompt to the prompts file
    /// </summary>
    public void AddCustomPrompt()
    {

    }
}
