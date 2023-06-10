public class Animation
{
    private int _animationSeconds;
    private List<string> _animationCharacters;

    public int AnimationSeconds
    {
        get {return _animationSeconds;}
        set {_animationSeconds = value;}
    }

    public List<string> AnimationCharacters
    {
        get {return _animationCharacters;}
        set {_animationCharacters = value;}
    }
}