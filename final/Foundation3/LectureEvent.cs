public class LectureEvent : Event
{
  private string _speaker;
  private int _capacity;

  public LectureEvent()
  {
    _type = "Lecture";
    _speaker = Utils.GetUserString("Enter the speaker's name: ");
    _capacity = Utils.GetUserInt("Enter the event capacity: ");
  }

  public LectureEvent(string title, string description, DateTime date, Address address, string speaker, int capacity)
    : base(title, description, date, address)
  {
    _type = "Lecture";
    _speaker = speaker;
    _capacity = capacity;
  }

  public override void DisplayFullDetails()
  {
    Console.WriteLine($"Event type: {_type}");
    Console.WriteLine($"Event title: {_title}");
    Console.WriteLine($"Speaker: {_speaker}");
    Console.WriteLine($"Capacity: {_capacity}\n");

    Console.WriteLine($"- {_description}\n");
    Console.WriteLine($"Time:");
    Console.WriteLine($"- {_date.ToShortDateString()} at {_date.ToShortTimeString()}\n");
    Console.WriteLine($"Address");
    _address.DisplayAddress();
  }
}