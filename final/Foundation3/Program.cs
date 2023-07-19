using System;

class Program
{
  static void Main(string[] args)
  {
    Console.Clear();

    string lectureTitle = "Tech Expo 2023";
    string lectureDescription = "Join us for a showcase of the latest technological advancements.";
    Address lectureAddress = new Address("123 Tech Street", "Tech City", "Tech State", "Techland", "12345");
    DateTime lectureDate = new DateTime(2023, 10, 15, 9, 0, 0);
    string lectureSpeaker = "Steve Jobs";
    int capacity = 5000;

    LectureEvent lectureEvent = new LectureEvent(
        title: lectureTitle,
        description: lectureDescription,
        address: lectureAddress,
        date: lectureDate,
        speaker: lectureSpeaker,
        capacity: capacity
        );


    string receptionTitle = "Grand Opening Reception";
    string receptionDescription = "Join us for the grand opening reception of our new location.";
    Address receptionAddress = new Address("456 Main Street", "Cityville", "Stateville", "Countryland", "54321");
    DateTime receptionDate = new DateTime(2023, 11, 1, 18, 30, 0);
    string receptionEmail = "reception@example.com";

    ReceptionEvent receptionEvent = new ReceptionEvent(
        title: receptionTitle,
        description: receptionDescription,
        address: receptionAddress,
        date: receptionDate,
        email: receptionEmail
        );


    string outdoorTitle = "Summer Music Festival";
    string outdoorDescription = "Enjoy live music performances under the open sky.";
    Address outdoorAddress = new Address("Park Avenue", "Cityville", "Stateville", "Countryland", "54321");
    DateTime outdoorDate = new DateTime(2023, 7, 22, 16, 0, 0);
    string weather = "30°C - Sunny with a slight breeze";

    OutdoorEvent outdoorEvent = new OutdoorEvent(
        title: outdoorTitle,
        description: outdoorDescription,
        address: outdoorAddress,
        date: outdoorDate,
        weather: weather
        );

    var events = new List<Event>();

    events.Add(lectureEvent);
    events.Add(receptionEvent);
    events.Add(outdoorEvent);

    int index = 1;
    foreach (Event eventType in events)
    {
      Console.Clear();
      Console.WriteLine($"------- EVENT {index} -------");
      Console.WriteLine("\n------SHORT DESCRIPTION------");
      eventType.DisplayShortDescription();

      Console.WriteLine("\n\n------STANDARD DETAILS------");
      eventType.DisplayStandardDetails();

      Console.WriteLine("\n\n------FULL DETAILS------");
      eventType.DisplayFullDetails();

      Console.WriteLine("Press any key to display next event...");
      Console.ReadLine();
      index++;
    }

  }
}