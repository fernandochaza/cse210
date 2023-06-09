public class Animation
{
    private int _duration;
    private List<string> _animationCharacters;

    public Animation()
    {
        _animationCharacters = new List<string>();
        _duration = 0;
    }


    public int Duration
    {
        get {return _duration;}
        set {_duration = value;}
    }

    public List<string> Characters
    {
        get {return _animationCharacters;}
        set {_animationCharacters = value;}
    }

}