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