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
    public DateTime _time;

    public void AddEntry(string prompt)
    {
        _prompt = prompt;
        Console.Write($"{_prompt}\n> ");
        _answer = Console.ReadLine();
        _date = DateTime.Today;
        _time = DateTime.Now;
    }

    public string ReturnEntry()
    {
        return $"\nDate: {_date.ToString("d")}  Time: {_time.ToString("HH:mm")}\n- Prompt: {_prompt}\n- My Answer: {_answer}\n";
    }

    public string SaveEntry()
    {
        return $"{_date.ToString("d")}|{_time.ToString("HH:mm")}|{_prompt}|{_answer}";
    }
}