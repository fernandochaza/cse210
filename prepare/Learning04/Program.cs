using System;

class Program
{
    static void Main(string[] args)
    {
        string name = "Fernando Chazarreta";
        string topic = "Inheritance";

        Assignment assignment = new Assignment(name, topic);
        Console.WriteLine(assignment.GetSummary());
    }
}