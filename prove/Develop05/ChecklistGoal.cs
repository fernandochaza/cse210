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
        _repetitionsToComplete = Utils.GetUserInt("How many times does this goal need to be accomplished for a bonus? ");
        _currentRepetitions = 0;
        _bonusPoints = Utils.GetUserInt("What is the bonus for accomplishing it that many times? ");
    }


    public override void ParseGoal(string stringGoal)
    {
        string[] parts = stringGoal.Split("|");
        int type = int.Parse(parts[0]);
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool isCompleted = bool.Parse(parts[4]);
        int currentRepetitions = int.Parse(parts[5]);
        int repetitionsToComplete = int.Parse(parts[6]);
        int bonusPoints = int.Parse(parts[7]);

        _typeID = type;
        _name = name;
        _shortDescription = description;
        _points = points;
        _isCompleted = isCompleted;
        _currentRepetitions = currentRepetitions;
        _repetitionsToComplete = repetitionsToComplete;
        _bonusPoints = bonusPoints;
    }


    public override void MarkCompleted()
    {

    }


    /// <summary>
    /// Return a string informing the goal Status
    /// </summary>
    /// <returns></returns>
    public override string GetGoalStatus()
    {
        string statusMark;

        if (_isCompleted)
        {
            statusMark = "[X]";
        }
        else
        {
            statusMark = "[ ]";
        }

        return $"{statusMark} {_name} ({_shortDescription}) --- Currently completed: {_currentRepetitions}/{_repetitionsToComplete}";
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