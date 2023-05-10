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

    public void AddEntry(string prompt)
    {
        _prompt = prompt;
        Console.Write($"{_prompt}\n> ");
        _answer = Console.ReadLine();
        _date = DateTime.Today;
    }

    public string ReturnEntry()
    {
        return $"Date: {_date.ToString("d")} - Prompt: {_prompt}\nMy Answer: {_answer}";
    }

    public string SaveEntry()
    {
        return $"{_date.ToString("d")}|{_prompt}|{_answer}";
    }
}