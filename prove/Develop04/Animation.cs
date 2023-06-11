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

    /// <summary>
    /// Initialize an animation without the time left restriction
    /// </summary>
    public void Initialize()
    {
        int animationTimeLeft = AnimationSeconds;
        int index = 0;

        do
        {
            Console.Write(AnimationCharacters[index]);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the character
            index++;
            animationTimeLeft--;

            if (index >= AnimationCharacters.Count())
            {
                index = 0;
            }
        } while (animationTimeLeft > 0);
    }

    /// <summary>
    /// Initialize the animation given the total time left of the session
    /// </summary>
    public void Initialize(int totalTimeLeft)
    {
        int animationTimeLeft = AnimationSeconds;
        int index = 0;

        do
        {
            Console.Write(AnimationCharacters[index]);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the character

            index++;
            animationTimeLeft--;
            totalTimeLeft--;

            if (index >= AnimationCharacters.Count())
            {
                index = 0;
            }

            if (totalTimeLeft == 0)
            {
                break;
            }

        } while (animationTimeLeft > 0);
    }
}