
using Microsoft.VisualBasic;

public class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public string Display()
    {
        return $"{_jobTitle} ({_company}) {_startYear}-{_endYear}";
    }


}

class Resume
{
    public string _nameFirst;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_nameFirst}");
        Console.WriteLine($"Experiences:");

        foreach (Job job in _jobs)
        {
            Console.WriteLine($"{job.Display()}");
        }
    }

}