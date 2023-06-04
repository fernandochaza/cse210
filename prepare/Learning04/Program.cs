using System;

class Program
{
    static void Main(string[] args)
    {
        string name = "Fernando Chazarreta";
        string topic = "Inheritance";
        string section = "9.8";
        string problems = "1-10";
        string title = "Alice in wonderland";

        Assignment assignment = new Assignment(name, topic);
        Console.WriteLine(assignment.GetSummary());

        MathAssignment mathAssignment = new MathAssignment(name, topic, section, problems);

        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        WritingAssignment writingAssignment = new WritingAssignment(name, topic, title);
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}