/// <summary>
/// The activity model includes the activity Title, Messages and Duration
/// </summary>
public class Activity
{
    private string _title;
    private string _description;
    private int _timeLeft;
    private int _activityDuration;
    private Countdown _countdown;
    private Spinner _spinner;

    public string Title
    {
        get {return _title;}
        set {_title = value;}
    }

    public string Description
    {
        set {_description = value;}
    }

    /// <summary>
    /// Get/Set the remaining time for the current session
    /// </summary>
    /// <value>Time in seconds</value>
    public int TimeLeft
    {
        get {return _timeLeft;}
        set {_timeLeft = value;}
    }

    /// <summary>
    /// Displays a default welcome message using the Activity Title and Description
    /// </summary>
    private void DisplayWelcome()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_title}.");
        Console.WriteLine($"\n{_description}");
    }

    /// <summary>
    /// Displays a default ending message informing the total time of the performed Activity
    /// </summary>
    public void EndMessage(Spinner spinner)
    {
        // Set the spinner duration
        spinner.AnimationSeconds = 5;

        Console.Clear();
        Console.WriteLine("Well done!");
        spinner.Initialize();
        Console.WriteLine($"\nYou have completed {_activityDuration} seconds of the {_title}");
        spinner.Initialize();
        Console.Clear();
    }

    /// <summary>
    /// Validate and Set the total time for the session in seconds.
    /// </summary>
    private void SetDuration()
    {
        while (true)
        {
            Console.Write("\nHow long, in seconds, would you like for your session? ");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out _timeLeft))
            {
                // Save the total time in a separate variable
                _activityDuration = _timeLeft;

                // Valid number entered, break out of the loop
                break;
            }

        Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    /// <summary>
    /// Instantiate a Spinner Animation given its desired duration
    /// </summary>
    /// <param name="duration">Time in seconds</param>
    public void Spinner(int duration)
    {
        _spinner = new Spinner(duration);
        _spinner.Initialize(TimeLeft);
    }

    /// <summary>
    /// Instantiate a Countdown Animation given its desired duration
    /// </summary>
    /// <param name="duration">Time in seconds</param>
    public void Countdown(int duration)
    {
        _countdown = new Countdown(duration);
        _countdown.Initialize(TimeLeft);
    }

    public void InitializeActivity(Activity activity)
    {
        activity.DisplayWelcome();

        // Ask the user for the session duration
        activity.SetDuration();
        Console.Clear();

        // Display a preparation message
        Console.WriteLine("Get ready...");
        Spinner(5);
    }
}