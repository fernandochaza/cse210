public class Countdown : Animation
{
    /// <summary>
    /// Instantiate a countdown timer given its duration in seconds
    /// </summary>
    /// <param name="duration">Time in seconds</param>
    public Countdown(int duration)
    {
        // Assign the given seconds as the Countdown Duration
        AnimationSeconds = duration;

        // Reverse loop to create a list of numbers in reverse order, starting at the duration time in seconds.
        List<string> characters = new List<string>();
        for (int i = duration; i > 0; i--)
        {
            characters.Add(i.ToString());
        }

        // Assign the resulting characters to the Animation String
        AnimationCharacters = characters;
    }
}