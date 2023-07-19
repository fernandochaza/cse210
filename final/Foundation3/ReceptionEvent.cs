public class ReceptionEvent : Event
{
  private string _registrationEmail;

  public ReceptionEvent(string type, string title, string description, DateTime date, Address address, string email)
    : base(title, description, date, address)
  {
    _type = "Reception";
    _registrationEmail = email;
  }

  public override void DisplayFullDetails()
  {
    Console.WriteLine($"Event type: {_type}");
    Console.WriteLine($"Event title: {_title}");
    Console.WriteLine($"RSVP Email: {_registrationEmail}");

    Console.WriteLine($"- {_description}\n");
    Console.WriteLine($"Time:");
    Console.WriteLine($"- {_date.ToShortDateString()} at {_date.ToShortTimeString()}\n");
    Console.WriteLine($"Address");
    _address.DisplayAddress();
  }
}