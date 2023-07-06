using System;

class Program
{
  static void Main(string[] args)
  {		
		Ingredient chicken = Ingredient.CreateIngredient();
		Console.WriteLine(chicken.ToString());

		chicken.Serialize();

		chicken.Deserialize();
  }
}
