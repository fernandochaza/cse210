using System;

class Program
{
  static void Main(string[] args)
  {
    Meal milanesas = Meal.Create();
    milanesas.Serialize();
    milanesas.Deserialize();
  }
}
