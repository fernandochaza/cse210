// Responsibilities:
// - Generate a random prompt

/// <summary>
/// Generate a random prompt
/// </summary>
public class Prompt
{
    public string[] _prompts = new string[]
    {
        "Who was the most interesting person you interacted with today?",
        "What was the happiest moment you experienced recently?",
        "Did you do help somebody today?",
        "Where do you feel most relaxed, and why?",
        "Why do you appreciate your closest friend?",
        "How do you recharge when you feel overwhelmed?",
        "Who is someone that inspires you, and why?",
        "Is there something that you're looking forward to in the near future?",
        "Did you tried something new recently? How did it make you feel?",
        "What are you doing toward your goals?"
    };

    public string ReturnRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Length);
        return _prompts[index];
    }
}