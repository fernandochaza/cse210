public abstract class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string Color
    {
        get {return _color;}
        set {_color = value;}
    }

    public abstract double GetArea();

}