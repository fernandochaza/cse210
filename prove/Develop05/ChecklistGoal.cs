public class ChecklistGoal : Goal
{
    private int _repetitionsToComplete;
    private int _currentRepetitions;
    private int _bonusPoints;

    public ChecklistGoal()
    {
        _typeName = "Checklist Goal";
    }


    public override void Initialize()
    {
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _shortDescription = Console.ReadLine();
        _points = Utils.GetUserInt("What is the amount of points associated with this goal? ");
        _repetitionsToComplete = Utils.GetUserInt("");
        _currentRepetitions = 0;
        _bonusPoints = Utils.GetUserInt("");
    }


    public override void MarkCompleted()
    {

    }

    public override void DisplayGoal()
    {

    }

    /// <summary>
    /// Generate a one-line string to represent the Goal with it's values separated by a pipe symbol "|".
    /// </summary>
    /// <returns>A one line string</returns>
    public override string GetStringRepresentation()
    {
        return $"{_typeID}|{_name}|{_shortDescription}|" +
        $"{_points}|{_isCompleted}|{_currentRepetitions}|{_repetitionsToComplete}|{_bonusPoints}";
    }
}