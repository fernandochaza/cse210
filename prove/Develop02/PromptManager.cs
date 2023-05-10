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
    public void AddPrompt(string prompt)
    {
        int id = _prompts.Count() + 1;
        _prompts.Add(id, prompt);
        SavePrompts();
        Console.Write("\n> Your new prompt was successfully added to the database.\n" +
        "\nPress Enter to continue...");
        Console.ReadLine();
    }

    /// <summary>
    /// Remove a prompt
    /// </summary>
    public void RemovePrompt()
    {
        DisplayPrompts();
        Console.Write("Enter the prompt number to remove: ");
        int promptKey = int.Parse(Console.ReadLine());

        string oldPrompt;
        _prompts.TryGetValue(promptKey, out oldPrompt);

        if (_prompts.Remove(promptKey))
        {
            for (int i = promptKey; i <= _prompts.Count(); i++)
            {
                _prompts.Add(i, _prompts[i+1]);
                _prompts.Remove(i+1);
            }
            SavePrompts();
            Console.WriteLine($"The prompt \"{oldPrompt}\" was removed");
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        };
    }

    /// <summary>
    /// Display the complete list of prompts with their IDs
    /// </summary>
    public void DisplayPrompts()
    {
        Console.WriteLine("\n> This is the list of prompts: ");
        foreach (KeyValuePair<int, string> prompt in _prompts)
        {
            Console.WriteLine($"    ({prompt.Key}) {prompt.Value}");
        }
    }

    public void SavePrompts()
    {
        using (StreamWriter outputFile = new StreamWriter("prompts.txt"))
        {
            foreach (KeyValuePair<int, string> prompt in _prompts)
                {
                    outputFile.WriteLine($"{prompt.Key},{prompt.Value}");
                }
        }
    }
}
