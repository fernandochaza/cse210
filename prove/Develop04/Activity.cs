/// <summary>
/// The activity model includes the activity Title, Messages and Duration
/// </summary>
public class Activity
{
    private string _title;  // Breathing Activity 
    private string _description;
    private string _endMessage;
    private int _duration;
    private Animation _pauseAnimation;

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

}