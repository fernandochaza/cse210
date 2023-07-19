public abstract class Event
{
  protected string _type;
  protected string _title;
  protected string _description;
  protected DateTime _date;
  protected Address _address;

  public Event()
  {
    _title = Utils.GetUserString("Enter the event title: ");
    _description = Utils.GetUserString("Enter the event description: ");

    DateTime? date = null;
    do
    {
      date = Utils.GetDate();

    } while (date == null);

    DateTime? dateAndTime = null;
    do
    {
      dateAndTime = Utils.GetTime(date.Value);

    } while (dateAndTime == null);

    _date = dateAndTime.Value;

    Address address = new Address();
    _address = address;
  }

  public Event(string title, string description, DateTime date, Address address)
  {
    _title = title;
    _description = description;
    _date = date;
    _address = address;
  }

  public void DisplayStandardDetails()
  {
    Console.WriteLine($"Event: {_title}");
    Console.WriteLine($"- {_description}\n");
    Console.WriteLine($"Time:");
    Console.WriteLine($"- {_date.ToShortDateString()} at {_date.ToShortTimeString()}\n");
    Console.WriteLine($"Address");
    _address.DisplayAddress();
  }

  public void DisplayShortDescription()
  {
    Console.WriteLine($"Event type: {_type}");
    Console.WriteLine($"Event title: {_title}");
    Console.WriteLine($"Event Date: {_date.ToShortDateString()} at {_date.ToShortTimeString()}\n");
  }

  public abstract void DisplayFullDetails();
}