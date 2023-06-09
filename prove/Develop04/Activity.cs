/// <summary>
/// The activity model includes the activity Title, Messages and Duration
/// </summary>
public class Activity
{
    private string _title;
    private string _description;
    private int _duration;

    public Activity()
    {
    }

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
/// Displays a default welcome message using the Activity Title and Description
/// </summary>
    public void DisplayWelcome()
    {
        Console.WriteLine($"Welcome to the {_title}.");
        Console.WriteLine($"\n{_description}");
    }

    public void EndMessage()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"\nYou have completed {_duration} seconds of {_title}");
    }

    public void SetDuration()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out _duration))
            {
                // Valid number entered, break out of the loop
                break;
            }

        Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}