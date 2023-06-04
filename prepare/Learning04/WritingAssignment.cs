public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string name, string topic) : base(name, topic)
    {

    }

    public WritingAssignment(string name, string topic, string title) : base(name, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        return $"{_title} by {StudentName}";
    }
}