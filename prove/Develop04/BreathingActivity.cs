public class BreathingActivity : Activity
{
    private int breatheInSeconds;
    private int breatheOutSeconds;

    /// <summary>
    /// Instantiate a Breathing Activity and set its Title and Description
    /// </summary>
    public BreathingActivity()
    {
        Title = "Breathing Activity";
        Description = "This activity will help you relax by walking through breathing in and out slowly. " +
        "Clear your mind and focus on your breathing.";
        breatheInSeconds = 4;
        breatheOutSeconds = 7;
    }

    public void Initialize()
    {
        // Determine the end time
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(TimeLeft);

        // Display the breathing messages until the current time reaches the determined End Time
        while (DateTime.Now <= endTime)
        {
            // Check the "TimeLeft", which is an Activity class member, to avoid Countdown after the time has ended.
            if (TimeLeft > 0)
            {
                Console.Write("\nBreathe In... ");
                Countdown(breatheInSeconds);

                // Update the Activity remaining time
                TimeLeft = TimeLeft - breatheInSeconds;
            }

            // Check the "TimeLeft", which is an Activity class member, to avoid Countdown after the time has ended.
            if (TimeLeft > 0)
            {
                Console.Write("\n\nBreathe Out...");
                Countdown(breatheOutSeconds);

                // Update the Activity remaining time
                TimeLeft = TimeLeft - breatheOutSeconds;
                Console.WriteLine();
            }
        }
    }
}