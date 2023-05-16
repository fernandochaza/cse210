/// <summary>
/// Hold a fraction and represent it as a string fraction or as a decimal value
/// 
/// </summary>
public class Fraction
{
    private int _top;
    private int _bottom;

    // Create constructor to initialize the number to 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Create constructor to initialize the number to a fraction where
    // the given wholeNumber is the numerator and the denominator is 1
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // Create a constructor that takes 2 parameters.
    // One for the numerator and other for the denominator
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public int GetTop()
    {
        return _top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public int SetTop(int number)
    {
        return _top = number;
    }

    public int SetBottom(int number)
    {
        return _bottom = number;
    }
    
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}