using System;
using System.Linq;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Group { get; set; }

    public Student(string firstName, string lastName, int group)
    {
        FirstName = firstName;
        LastName = lastName;
        Group = group;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
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
            string firstName = parts[0];
            string lastName = parts[1];
            int group = int.Parse(parts[2]);
            students.Add(new Student(firstName, lastName, group));
        }

        var result = students.Where(s => s.Group == 2).OrderBy(s => s.FirstName);

        foreach (var student in result)
        {
            Console.WriteLine(student);
        }
    }
}