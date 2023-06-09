public class Animation
{
    private int _pauseDuration;
    private List<string> _animationCharacters;

    public Animation()
    {
        _animationCharacters = new List<string>();
        _pauseDuration = 0;
    }


    public int PauseDuration
    {
        get {return _pauseDuration;}
        set {_pauseDuration = value;}
    }

    public List<string> Characters
    {
        get {return _animationCharacters;}
        set {_animationCharacters = value;}
    }

}