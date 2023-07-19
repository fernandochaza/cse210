public class Address
{
  private string _street;
  private string _city;
  private string _state;
  private string _country;
  private string _postalCode;

  public Address(string street, string city, string state, string country, string postalCode)
  {
    _street = street;
    _city = city;
    _state = state;
    _country = country;
    _postalCode = postalCode;
  }

  public Address()
  {
    _street = Utils.GetUserString("Enter the street: ");
    _city = Utils.GetUserString("Enter the city: ");
    _state = Utils.GetUserString("Enter the state: ");
    _country = Utils.GetUserString("Enter the country: ");
    _postalCode = Utils.GetUserString("Enter the postal code: ");
  }

  public void DisplayAddress()
  {
    Console.WriteLine($"- {_street}");
    Console.WriteLine($"- {_city} - {_state} - PC:{_postalCode}");
    Console.WriteLine($"- {_country}");
  }

  public string GetAddress()
  {
    return null;
  }
}