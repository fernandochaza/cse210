public class Spinner : Animation
{
    /// <summary>
    /// Instantiate a spinner timer given its duration in seconds
    /// </summary>
    /// <param name="duration">Time in seconds</param>
    public Spinner(int duration)
    {
        // Assign the given seconds as the Spinner Duration
        Duration = duration;

        // Create the list of characters that simulates a spinner
        Characters = new List<string>{"|", "/", "-", "\\"};
    }

    public void Initialize()
    {
        int timeLeft = Duration;
        int index = 0;

        do
        {
            Console.Write(Characters[index]);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the + character
            index++;
            timeLeft--;
            if (index >= Characters.Count())
            {
                index = 0;
            }

        } while (timeLeft > 0);
    }
}