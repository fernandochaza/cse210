public class Circle : Shape
{
    private double _radius;

    public Circle()
    {
    }

    public Circle(string color, double radius) : base (color)
    {
        _radius = radius;
    }

    public double Radius
    {
        get {return _radius;}
        set {_radius = value;}
    }

    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}