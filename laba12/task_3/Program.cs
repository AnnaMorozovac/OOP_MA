using System;
using System.Collections.Generic;
using System.Linq;

interface IEmployee
{
    string Name { get; }
    int WorkHoursPerWeek { get; }
}

class StandartEmployee : IEmployee
{
    public string Name { get; }
    public int WorkHoursPerWeek => 40;

    public StandartEmployee(string name)
    {
        Name = name;
    }
}

class PartTimeEmployee : IEmployee
{
    public string Name { get; }
    public int WorkHoursPerWeek => 20;

    public PartTimeEmployee(string name)
    {
        Name = name;
    }
}

class Job
{
    public string Name { get; }
    public int HoursRequired { get; private set; }
    public IEmployee Employee { get; }

    public event EventHandler<Job> JobDone;

    public Job(string name, int hoursRequired, IEmployee employee)
    {
        Name = name;
        HoursRequired = hoursRequired;
        Employee = employee;
    }

    public void Update()
    {
        HoursRequired -= Employee.WorkHoursPerWeek;
        if (HoursRequired <= 0)
        {
            Console.WriteLine($"Job {Name} done!");
            JobDone?.Invoke(this, this);
        }
    }

    public override string ToString()
    {
        return $"Job: {Name} Hourse Remaining: {HoursRequired}";
    }
}

class JobList
{
    private List<Job> jobs = new List<Job>();

    public void AddJob(Job job)
    {
        jobs.Add(job);
        job.JobDone += OnJobDone;
    }

    private void OnJobDone(object sender, Job job)
    {
        jobs.Remove(job);
    }

    public void PassWeek()
    {
        foreach (var job in new List<Job>(jobs))
        {
            job.Update();
        }
    }

    public void Status()
    {
        foreach (var job in jobs)
        {
            Console.WriteLine(job);
        }
    }
}

class Program
{
    static void Main()
    {
        var employees = new Dictionary<string, IEmployee>();
        var jobs = new JobList();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0];

            switch (command)
            {
                case "StandardEmployee":
                    employees[parts[1]] = new StandartEmployee(parts[1]);
                    break;
                case "PartTimeEmployee":
                    employees[parts[1]] = new PartTimeEmployee(parts[1]);
                    break;

                case "Job":
                    string jobName = parts[1];
                    int hourse = int.Parse(parts[2]);
                    string empName = parts[3];
                    var job = new Job(jobName, hourse, employees[empName]);
                    jobs.AddJob(job);
                    break;
                case "Pass":
                    jobs.PassWeek();
                    break;
                case "Status":
                    jobs.Status();
                    break;
            }
        }
    }
}