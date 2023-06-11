public class ReflectionActivity : Activity
{
    private string _promptsDatabase = "reflection-prompts.txt";
    private Dictionary<int, string> _prompts = new Dictionary<int, string>();
    private string _questionsDatabase = "questions.txt";
    private List<string> _questions = new List<string>();
    private int _reflectionTime;


    /// <summary>
    /// Instantiate a Breathing Activity and set its Title and Description
    /// </summary>
    public ReflectionActivity()
    {
        // Set Title and Description
        Title = "Reflection Activity";
        Description = "This activity will help you reflect on times in your life when you have " +
        "shown strength and resilience. This will help you recognize the power you have " +
        "and how you can use it in other aspects of your life.";

        // Set the duration for each reflection question
        _reflectionTime = 6;

        // Load prompts from a txt file
        string[] lines = System.IO.File.ReadAllLines(_promptsDatabase);
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            int id = int.Parse(parts[0]);
            string prompt = parts[1];
            _prompts.Add(id, prompt);
        }

        // Load questions from a txt file
        string[] questions = System.IO.File.ReadAllLines(_questionsDatabase);
        foreach (string question in questions)
        {
            _questions.Add(question);
        }

    }

    public List<string> Questions
    {
        set {_questions = value;}
        get {return _questions;}
    }

        /// <summary>
    /// Select a random prompt from a predefined array of prompts
    /// </summary>
    /// <returns>A random prompt</returns>
    public void DisplayRandomPrompt()
    {
        Random random = new Random();
        int key = random.Next(_prompts.Count);
        string prompt = _prompts[key];

        Console.WriteLine("\nConsider the following prompt: \n");
        Console.WriteLine($"{prompt}\n");

        Console.Write("When you have something in mind, press any key to continue... ");
        Console.ReadLine();
    }

    /// <summary>
    /// Randomly reorder the list of questions
    /// </summary>
    public void ReorderQuestions()
    {
        Random random = new Random();

        int quantity = _questions.Count();

        while (quantity > 1)
        {
            quantity--;

            // Generate a random index within the range of the remaining questions
            int randomIndex = random.Next(quantity+1);

            // Get the question at the random index
            string randomQuestion = Questions[randomIndex];

            // Place the last question at the place of the randomIndex
            Questions[randomIndex] = Questions[quantity];

            // Place the random question at the end of the list 
            Questions[quantity] = randomQuestion;
        }
    }

    /// <summary>
    /// Display the ponder questions randomly reordered until the session is over
    /// </summary>
    public void DisplayQuestions()
    {
        // Reorder the questions list to ensure the user get different questions each run
        ReorderQuestions();

        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        Countdown(5);
        Console.WriteLine();

        // Determine the end time
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(TimeLeft);

        // Display the questions until the current time reaches the determined End Time
        while (DateTime.Now <= endTime)
        {
            foreach (string question in _questions)
            {
                // Check the "TimeLeft", which is an Activity class member, to avoid Countdown after the time has ended.
                if (TimeLeft > 0)
                {
                    Console.Write($"{question} ");
                    Spinner(_reflectionTime);
                    Console.WriteLine();
                }
                // Update the Activity remaining time
                TimeLeft = TimeLeft - _reflectionTime;
                Console.WriteLine();
            }

            // If there is time left, reorder the questions again
            ReorderQuestions();
        }
    }
}