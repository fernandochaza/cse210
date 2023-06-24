public class ChecklistGoal : Goal
{
    private int _repetitionsToComplete;
    private int _currentRepetitions;
    private int _bonusPoints;

    public ChecklistGoal()
    {
        _type = "Checklist Goal";
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
        return $"{_type}|{_name}|{_shortDescription}|" +
        $"{_points}|{_isCompleted}|{_currentRepetitions}|{_repetitionsToComplete}|{_bonusPoints}";
    }
}