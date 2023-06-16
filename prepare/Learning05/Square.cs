public class Square : Shape
{
    private double _side;

    public Square()
    {
    }

    public Square(string color, double side) : base (color)
    {
        _side = side;
    }

    public double Side
    {
        get {return _side;}
        set {_side = value;}
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}