public class Countdown : Animation
{
    /// <summary>
    /// Instantiate a countdown timer given its duration in seconds
    /// </summary>
    /// <param name="duration">Time in seconds</param>
    public Countdown(int duration)
    {
        // Assign the given seconds as the Countdown Duration
        Duration = duration;

        // Reverse loop to create a list of numbers in reserve order, starting at the duration time in seconds.
        List<string> characters = new List<string>();
        for (int i = duration; i > 0; i--)
        {
            characters.Add(i.ToString());
        }

        // Assign the resulting characters to the Animation String
        Characters = characters;
    }

    /// <summary>
    /// Initialize a countdown starting at the defined Animation Duration
    /// </summary>
    public void Initialize()
    {
        int timeLeft = Duration;
        int index = 0;

        do
        {
            Console.Write(Characters[index]);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the character
            index++;
            timeLeft--;
            if (index >= Characters.Count())
            {
                index = 0;
            }
        } while (timeLeft > 0);
    }
}