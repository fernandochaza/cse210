public abstract class Goal
{
    protected int _typeID;
    protected string _typeName;
    protected string _name;
    protected string _shortDescription;
    protected int _points;
    protected bool _isCompleted;
    protected int _timesCompleted;


    /// <summary>
    /// Get the goal data from the user.
    /// </summary>
    public virtual void RequestGoalData()
    {
        Utils.DisplayText("> What is the name of your goal? ");
        _name = Console.ReadLine();
        Utils.DisplayText("> What is a short description of it? ");
        _shortDescription = Console.ReadLine();
        _points = Utils.GetUserInt("> What is the amount of points associated with this goal? ");
    }


    /// <summary>
    /// Change the goal status as Completed OR add a new goal repetition
    /// </summary>
    public abstract void NewEvent();


    /// <summary>
    /// Return a string informing the goal Status
    /// </summary>
    /// <returns></returns>
    public abstract string GetGoalStatus();


    /// <summary>
    /// Get the points earned from the Goal completion
    /// </summary>
    /// <returns></returns>
    public abstract int GetScore();



    /// <summary>
    /// Generate a one-line string to represent the Goal with it's values separated by a pipe symbol "|".
    /// </summary>
    /// <returns>A one line string</returns>
    public virtual string GetStringRepresentation()
    {
        return $"{_typeID}|{_name}|{_shortDescription}|{_points}|{_isCompleted}|{_timesCompleted}";
    }


    public bool IsCompleted
    {
        get {return _isCompleted;}
        set {_isCompleted = value;}
    }
}