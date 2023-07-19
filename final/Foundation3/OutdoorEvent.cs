public class OutdoorEvent : Event
{
  private string _weather;

  public OutdoorEvent()
  {
    _type = "Reception";
    _weather = Utils.GetUserString("Enter the weather conditions: ");
  }

  public OutdoorEvent(string title, string description, DateTime date, Address address, string weather)
    : base(title, description, date, address)
  {
    _type = "Outdoor";
    _weather = weather;
  }

  public override void DisplayFullDetails()
  {
    Console.WriteLine($"Event type: {_type}");
    Console.WriteLine($"Event title: {_title}");
    Console.WriteLine($"Weather: {_weather}");

    Console.WriteLine($"- {_description}\n");
    Console.WriteLine($"Time:");
    Console.WriteLine($"- {_date.ToShortDateString()} at {_date.ToShortTimeString()}\n");
    Console.WriteLine($"Address");
    _address.DisplayAddress();
  }
}