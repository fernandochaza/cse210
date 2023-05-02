public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public string DisplayResume()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        for (int jobNumber = 0; jobNumber < _jobs.Count; jobNumber++)
        {
            Console.WriteLine(_jobs[jobNumber].DisplayJob());
        }

        return "";
    }
}