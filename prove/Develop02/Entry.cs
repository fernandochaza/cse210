// Responsibilities:
// - Display a random prompt to the user
// - Get the user answer and current date
// - Create an entry with the prompt, answer and date
// - Display an entry (prompt, answer, date)

public class Entry
{
    public string _prompt;
    public string _answer;
    public DateTime _date;


    public Entry()
    {
        _prompt = "This is the prompt";
        Console.Write($"{_prompt}\n> ");
        _answer = Console.ReadLine();
        _date = DateTime.Today;
    }

    // public string CreateEntry()
    // {
    //     Console.WriteLine($"{_prompt}\n> ");
    //     _answer = Console.ReadLine();
    //     _date = DateTime.Today;

    //     return ReturnEntry();
    // }

    public string ReturnEntry()
    {
        return $"Date: {_date.ToString("d")} - Prompt: {_prompt}\nMy Answer: {_answer}";
    }

}