using System;

class Program
{
    static void Main(string[] args)
    {

        Job job1 = new Job();
        job1._jobTitle = "Cashier and Customer Service Rep.";
        job1._company = "Santander Argentina";
        job1._startYear = 2016;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Scrum Master";
        job2._company = "ID For Ideas";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume myResume = new Resume();
        myResume._name = "Fernando Chazarreta";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        Console.WriteLine(myResume.DisplayResume());

    }

}