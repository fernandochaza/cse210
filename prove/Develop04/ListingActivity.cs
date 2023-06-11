public class ListingActivity : Activity
{
    private string _promptsDatabase = "listing-prompts.txt";
    private List<string> _prompts = new List<string>();
    private List<string> _userList = new List<string>();

    public ListingActivity()
    {
        Title = "Listing Activity";
        Description = "This activity will help you reflect on the good things in your life by having you " +
        "list as many things as you can in a certain area.";

        // Load prompts from a txt file
        string[] prompts = System.IO.File.ReadAllLines(_promptsDatabase);
        foreach (string prompt in prompts)
        {
            _prompts.Add(prompt);
        }

    }

    public string ReturnRandomPrompt()
    {
        Random random = new Random();
        int promptIndex = random.Next(_prompts.Count());
        string prompt = _prompts[promptIndex];

        return prompt;
    }

    public void InitializeListing()
    {
        Console.Clear();
        Console.WriteLine("List as many responses you can to the following prompt: ");

        string prompt = ReturnRandomPrompt();
        Console.WriteLine($"\n--- {prompt} ---\n");

        Console.Write("You may begin in: ");
        Countdown(6);
        Console.WriteLine();

        // Determine the end time
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(TimeLeft);

        // Allow the user to list their thoughts
        while (DateTime.Now <= endTime)
        {
            Console.Write("> ");
            string answer = Console.ReadLine();
            _userList.Add(answer);

            // I don't know how to handle time while the user is in the middle
            // of typing their thoughts
        }

        int listedItems = _userList.Count;
        Console.Write($"\nYou listed {listedItems} items!!");
        Spinner(5);
    }
}