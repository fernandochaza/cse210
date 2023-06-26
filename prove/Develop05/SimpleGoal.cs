public class SimpleGoal : Goal
{
    public SimpleGoal()
    {
        _typeID = 1;
        _typeName = "Simple Goal";
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
}