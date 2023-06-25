public class Goal
{
    protected int _typeID;
    protected string _typeName;
    protected string _name;
    protected string _shortDescription;
    protected int _points;
    protected bool _isCompleted;


    public Goal()
    {
        
    }


    public virtual void Initialize()
    {
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _shortDescription = Console.ReadLine();
        _points = Utils.GetUserInt("What is the amount of points associated with this goal? ");
    }


    /// <summary>
    /// Get the Goal data from a string representation of the goal
    /// </summary>
    /// <param name="stringGoal">A one-line string representing the goal data separated by a pipe symbol "|"</param>
    public virtual void ParseGoal(string stringGoal)
    {
        string[] parts = stringGoal.Split("|");
        int type = int.Parse(parts[0]);
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool isCompleted = bool.Parse(parts[4]);

        _typeID = type;
        _name = name;
        _shortDescription = description;
        _points = points;
        _isCompleted = isCompleted;
    }




    public virtual void MarkCompleted()
    {

    }

    public virtual string GetGoalStatus()
    {

        return $"";
    }


    /// <summary>
    /// Generate a one-line string to represent the Goal with it's values separated by a pipe symbol "|".
    /// </summary>
    /// <returns>A one line string</returns>
    public virtual string GetStringRepresentation()
    {
        return $"{_typeID}|{_name}|{_shortDescription}|{_points}|{_isCompleted}";
    }


    protected int TypeID
    {
        set {_typeID = value;}
        get {return _typeID;}
    }
    
    
    protected string Name
    {
        set {_name = value;}
    }
    
    protected string Description
    {
        set {_shortDescription = value;}
    }
    
    protected int Points
    {
        set {_points = value;}
    }
    
    protected bool Completed
    {
        set {_isCompleted = value;}
    }
}