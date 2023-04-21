using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Prep2 Activity");

        string letterGrade;
        string sign = "";

        Console.Write("Enter your grade percentage: ");
        string valueFromUser = Console.ReadLine();

        float percentageGrade = float.Parse(valueFromUser);

        float reminder = percentageGrade % 10;

        if (percentageGrade > 60 && percentageGrade < 93)
        {
            if (reminder >= 7)
            {
                sign = "+";
            }
            else if (reminder < 3)
            {
                sign = "-";
            }
        }

        if (percentageGrade >= 70)
        {
            if (percentageGrade < 80)
            {
                letterGrade = "C" + sign;
            }
            else if (percentageGrade < 90)
            {
                letterGrade = "B" + sign;
            }
            else
            {
                letterGrade = "A" + sign;
            }
            Console.WriteLine($"Congratulations! You have passed the course with a letter grade of {letterGrade}!");
        }
        else 
        {
            if (percentageGrade > 59)
            {
                letterGrade = "D" + sign;
            }
            else
            {
                letterGrade = "F";
            }
        Console.WriteLine($"Your letter grade is {letterGrade}.");
        Console.WriteLine("You need a C to pass this course. Try again next time!");
        }
    }


}
