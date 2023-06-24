public class Goal
{
    protected string _type;
    protected string _name;
    protected string _shortDescription;
    protected int _points;
    protected bool _isCompleted;

    public Goal()
    {
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _shortDescription = Console.ReadLine();
        _points = GetUserInt("What is the amount of points associated with this goal? ");
    }


    public int GetUserInt(string message)
    {
        string userInput;
        int validInteger = 0;
        bool isValidNumber = false;

        while (!isValidNumber)
        {
            Console.Write(message);
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out validInteger))
            {
                isValidNumber = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        return validInteger;
    }


    public static Goal CreateGoal(int type)
    {
        switch (type)
        {
            case 1:
                return new SimpleGoal();
            case 2:
                return new EternalGoal();
            case 3:
                return new ChecklistGoal();
            default:
                Console.WriteLine("Invalid type");
                return null;
        }
    }

    public virtual void MarkCompleted()
    {

    }

    public virtual void DisplayGoal()
    {

    }

    /// <summary>
    /// Generate a one-line string to represent the Goal with it's values separated by a pipe symbol "|".
    /// </summary>
    /// <returns>A one line string</returns>
    public virtual string GetStringRepresentation()
    {
        return $"{_type}|{_name}|{_shortDescription}|{_points}|{_isCompleted}";
    }
}