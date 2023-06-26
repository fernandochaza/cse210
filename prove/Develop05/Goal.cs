public class Goal
{
    protected int _typeID;
    protected string _typeName;
    protected string _name;
    protected string _shortDescription;
    protected int _points;
    protected bool _isCompleted;
    protected int _timesCompleted;


    public Goal()
    {
        
    }


    /// <summary>
    /// Get the goal data from the user.
    /// </summary>
    public virtual void RequestGoalData()
    {
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _shortDescription = Console.ReadLine();
        _points = Utils.GetUserInt("What is the amount of points associated with this goal? ");
    }


    /// <summary>
    /// Instantiate the Goal variables from a string representation of the goal
    /// </summary>
    /// <param name="stringGoal">A one-line string representing the goal data separated by a pipe symbol "|"</param>
    public Goal(string stringGoal)
    {
        string[] parts = stringGoal.Split("|");
        int type = int.Parse(parts[0]);
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool isCompleted = bool.Parse(parts[4]);
        int timesCompleted = int.Parse(parts[5]);

        _typeID = type;
        _name = name;
        _shortDescription = description;
        _points = points;
        _isCompleted = isCompleted;
        _timesCompleted = timesCompleted;
    }



    public virtual void MarkCompleted()
    {
        _isCompleted = true;
    }


    /// <summary>
    /// Return a string informing the goal Status
    /// </summary>
    /// <returns></returns>
    public virtual string GetGoalStatus()
    {
        return "This is GetGoalStatus in Goal Class"; // I tried making this and abstract method but I'm have problems instantiating the Goal class
    }


    public virtual int GetScore()
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


    /// <summary>
    /// Generate a one-line string to represent the Goal with it's values separated by a pipe symbol "|".
    /// </summary>
    /// <returns>A one line string</returns>
    public virtual string GetStringRepresentation()
    {
        return $"{_typeID}|{_name}|{_shortDescription}|{_points}|{_isCompleted}|{_timesCompleted}";
    }


    protected int TypeID
    {
        set {_typeID = value;}
        get {return _typeID;}
    }


    public string TypeName
    {
        get {return _typeName;}
    }
    
    
    protected string Name
    {
        set {_name = value;}
    }
    
    protected string Description
    {
        set {_shortDescription = value;}
    }
    
    public int Points
    {
        get {return _points;}
        set {_points = value;}
    }
    
    public bool IsCompleted
    {
        get {return _isCompleted;}
        set {_isCompleted = value;}
    }

    public int TimesCompleted
    {
        get {return _timesCompleted;}
    }
}