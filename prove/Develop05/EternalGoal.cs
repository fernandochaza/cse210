public class EternalGoal : Goal
{
    public EternalGoal()
    {
        _typeID = 2;
        _typeName = "Eternal Goal";
    }


    /// <summary>
    /// Return a string informing the goal Status
    /// </summary>
    /// <returns></returns>
    public override string GetGoalStatus()
    {
        return $"{_typeName}: {_name} ({_shortDescription})";
    }


    public override void MarkCompleted()
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