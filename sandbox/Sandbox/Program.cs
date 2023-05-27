using System;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");

        List<Person> people = new List<Person>();

        Person person1 = new Person();
        Person person2 = new Person("Elon");
        Person person3 = new Person("Mark", 39);
        Person person4 = new Person("Fernando", 36, "My Address");

        people.AddRange(new Person[] {person1, person2, person3, person4});

        foreach (Person person in people)
        {
        Console.WriteLine($"Name: {person.Name}");
        Console.WriteLine($"Age: {person.Age}");
        Console.WriteLine($"Address: {person.Address}\n");
        }

        // Console.WriteLine($"Person 1\n    Name: {person1.Name} - Age: {person1.Age} - Address: {person1.Address}\n"); // Name:  - Age: 0 - Address:
        // Console.WriteLine($"Person 2\n    Name: {person2.Name} - Age: {person2.Age} - Address: {person2.Address}\n"); // Name: Elon - Age: 0 - Address:
        // Console.WriteLine($"Person 3\n    Name: {person3.Name} - Age: {person3.Age} - Address: {person3.Address}\n"); // Name: Mark - Age: 39 - Address:
        // Console.WriteLine($"Person 4\n    Name: {person4.Name} - Age: {person4.Age} - Address: {person4.Address}\n"); // Name: Fernando - Age: 36 - Address: My Address
    }
}