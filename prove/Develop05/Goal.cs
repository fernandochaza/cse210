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


    public void ParseGoal(string stringGoal)
    {
        string[] parts = stringGoal.Split("|");
        int type = int.Parse(parts[0]);
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool isCompleted = bool.Parse(parts[4]);

        if (parts.Length > 5)
        {
            int currentRepetitions = int.Parse(parts[5]);
            int repetitionsToComplete = int.Parse(parts[6]);
            int bonusPoints = int.Parse(parts[7]);
        }

        _typeID = type;
        _name = name;
        _shortDescription = description;
        _points = points;
        _isCompleted = isCompleted;
    }


    /// <summary>
    /// Create an instance of a determined Goal subclass given an integer option
    /// </summary>
    /// <param name="type">An integer that represent the Goal subclass. 
    /// (Options: 1=SimpleGoal, 2=EternalGoal, 3=ChecklistGoal)</param>
    /// <returns>A new instance of the required Goal subclass OR -null- if the type is incorrect</returns>
    public Goal GetGoalFromInt(int type)
    {
        switch (type)
        {
            case 1:
                SimpleGoal simpleGoal = new SimpleGoal();
                return simpleGoal;
            case 2:
                EternalGoal eternalGoal = new EternalGoal();
                return eternalGoal;
            case 3:
                ChecklistGoal checklistGoal = new ChecklistGoal();
                return checklistGoal;
            default:
                Console.WriteLine("Invalid type");
                return null;
        }
    }


    public virtual void MarkCompleted()
    {

    }

    public virtual void DisplayGoal()
    {

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