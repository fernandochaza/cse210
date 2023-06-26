public class SimpleGoal : Goal
{
    public SimpleGoal()
    {
        _typeID = 1;
        _typeName = "Simple Goal";
    }


    /// <summary>
    /// Instantiate the Goal variables from a string representation of the goal
    /// </summary>
    /// <param name="stringGoal">A one-line string representing the goal data separated by a pipe symbol "|"</param>
    public SimpleGoal(string stringGoal)
    {
        string[] parts = stringGoal.Split("|");
        int type = int.Parse(parts[0]);
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool isCompleted = bool.Parse(parts[4]);
        int timesCompleted = int.Parse(parts[5]);

        _typeID = type;
        _typeName = "Simple Goal";
        _name = name;
        _shortDescription = description;
        _points = points;
        _isCompleted = isCompleted;
        _timesCompleted = timesCompleted;
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

        return $"{_typeName}: {statusMark} {_name} ({_shortDescription})";
    }


    public override void MarkCompleted()
    {
        if (!_isCompleted)
            {
                _isCompleted = true;
                _timesCompleted = 1;
            }
        else
            {
                Console.WriteLine("(!) This goal is already completed!");
            }
    }


    public override int GetScore()
    {
        if (_isCompleted)
        {
            return _points;
        }
        else
        {
            return 0;
        }
    }
}