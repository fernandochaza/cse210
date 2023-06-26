public class EternalGoal : Goal
{
    public EternalGoal()
    {
        _typeID = 2;
        _typeName = "Eternal Goal";
    }


    /// <summary>
    /// Instantiate the Goal variables from a string representation of the goal
    /// </summary>
    /// <param name="stringGoal">A one-line string representing the goal data separated by a pipe symbol "|"</param>
    public EternalGoal(string stringGoal)
    {
        string[] parts = stringGoal.Split("|");
        int type = int.Parse(parts[0]);
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool isCompleted = bool.Parse(parts[4]);
        int timesCompleted = int.Parse(parts[5]);

        _typeID = type;
        _typeName = "Eternal Goal";
        _name = name;
        _shortDescription = description;
        _points = points;
        _isCompleted = isCompleted;
        _timesCompleted = timesCompleted;
    }


    public override string GetGoalStatus()
    {
        return $"{_typeName}: {_name} ({_shortDescription})";
    }


    public override void NewEvent()
    {
        _timesCompleted += 1;
    }

    
    public override int GetScore()
    {
        if (_timesCompleted > 0)
        {
            return _points * _timesCompleted;
        }
        else
        {
            return 0;
        }
    }
}