public class ChecklistGoal : Goal
{
    private int _repetitionsToBonus;
    private int _bonusPoints;

    public ChecklistGoal()
    {
        _typeID = 3;
        _typeName = "Checklist Goal";
    }

    
    /// <summary>
    /// Instantiate the Goal variables from a string representation of the goal
    /// </summary>
    /// <param name="stringGoal">A one-line string representing the goal data separated by a pipe symbol "|"</param>
    public ChecklistGoal(string stringGoal)
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
        _typeName = "Checklist Goal";
        _name = name;
        _shortDescription = description;
        _points = points;
        _isCompleted = isCompleted;
        _timesCompleted = currentRepetitions;
        _repetitionsToBonus = repetitionsToComplete;
        _bonusPoints = bonusPoints;
    }


    /// <summary>
    /// Get the goal data from the user.
    /// </summary>
    public override void RequestGoalData()
    {
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _shortDescription = Console.ReadLine();
        _points = Utils.GetUserInt("What is the amount of points associated with this goal? ");
        _repetitionsToBonus = Utils.GetUserInt("How many times does this goal need to be accomplished for a bonus? ");
        _timesCompleted = 0;
        _bonusPoints = Utils.GetUserInt("What is the bonus for accomplishing it that many times? ");
    }


    public override void MarkCompleted()
    {
        if (!_isCompleted)
        {
            _timesCompleted += 1;
            if (_timesCompleted == _repetitionsToBonus)
            {
                _isCompleted = true;
            }
        }
        else
        {
            Console.WriteLine("(!) This goal is already completed!");
        }
    }


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

        return $"{_typeName}: {statusMark} {_name} ({_shortDescription}) --- Currently completed: {_timesCompleted}/{_repetitionsToBonus}";
    }


    public override int GetScore()
    {
        if (_timesCompleted > 0)
        {
            if (_timesCompleted == _repetitionsToBonus)
            {
                return (_points * _timesCompleted) + _bonusPoints;
            }
            else
            {
                return _points * _timesCompleted;
            }
        }
        else
        {
            return 0;
        }
    }


    /// <summary>
    /// Generate a one-line string to represent the Goal with it's values separated by a pipe symbol "|".
    /// </summary>
    /// <returns>A one line string</returns>
    public override string GetStringRepresentation()
    {
        return $"{_typeID}|{_name}|{_shortDescription}|" +
        $"{_points}|{_isCompleted}|{_timesCompleted}|{_repetitionsToBonus}|{_bonusPoints}";
    }
}