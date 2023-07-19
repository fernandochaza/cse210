using System;

class Program
{
  static void Main(string[] args)
  {

    
    DateTime? date = null;
    do
    {
      date = Utils.GetDate();

    } while (date == null);

    DateTime? time = null;

    do
    {
      time = Utils.GetTime(date.Value);

    } while (time == null);
  }
}