public class Spinner : Animation
{
    /// <summary>
    /// Instantiate a spinner timer given its duration in seconds
    /// </summary>
    /// <param name="duration">Time in seconds</param>
    public Spinner(int duration)
    {
        // Assign the given seconds as the Spinner Duration
        AnimationSeconds = duration;

        // Create the list of characters that simulates a spinner
        AnimationCharacters = new List<string>{"|", "/", "-", "\\"};
    }

    /// <summary>
    /// Instantiate a spinner without an specific duration
    /// </summary>
    public Spinner()
    {
        // Create the list of characters that simulates a spinner
        AnimationCharacters = new List<string>{"|", "/", "-", "\\"};
    }
}