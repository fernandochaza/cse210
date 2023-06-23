public class Goal
{
    private string _type;
    private string _shortDescription;
    private string _longDescription;
    private int _points;
    private bool _isCompleted;

    public Goal()
    {

    }

    public void CreateGoal()
    {

    }

    public void MarkCompleted()
    {

    }

    public void DisplayGoal()
    {

    }

    /// <summary>
    /// Generate a one-line string to represent the Goal with it's values separated by a pipe symbol "|".
    /// </summary>
    /// <returns>A one line string</returns>
    public virtual string GetStringRepresentation()
    {
        return $"{_type}|{_shortDescription}|{_longDescription}|{_points}|{_isCompleted}";
    }
}