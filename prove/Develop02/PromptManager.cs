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
            int id = int.Parse(parts[0]);
            string prompt = parts[1];
            _prompts.Add(id, prompt);
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
    public void AddPrompt()
    {

    }

    /// <summary>
    /// Remove a prompt
    /// </summary>
    public void RemovePrompt(int id)
    {

    }

    public void DisplayPrompts()
    {
        string[] lines = System.IO.File.ReadAllLines("prompts.txt");

        Console.WriteLine("This is the list of prompts: ");
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            string id = parts[0];
            string prompt = parts[1];
            Console.WriteLine($"    ({id}) {prompt}");
        }
    }
}
