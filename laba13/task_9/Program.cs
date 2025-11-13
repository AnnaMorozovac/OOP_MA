using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string groupNumder;
    public List<int> Rating { get; }

    public string GroupNamber 
    {
        get { return groupNumder; }
        set
        {
            if (value.Length != 6)
            {
                throw new ArgumentException("Facult number has to have 6 digits");
            }
            groupNumder = value;
        }
    }

    public Student(string groups, List<int> rating)
    {
        GroupNamber = groups;
        Rating = rating;
    }
}

class Program
{
    static void Main()
    {
        var students = new List<Student>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] parts = input.Split(' ');
            string group = parts[0];
            var rating = parts.Skip(1).Select(int.Parse).ToList();
            students.Add(new Student(group, rating));
        }

        var result = students.Where(s => s.GroupNamber.EndsWith("14") || s.GroupNamber.EndsWith("15"));

        foreach (var student in result)
        {
            Console.WriteLine(string.Join(" ", student.Rating));
        }
    }
}