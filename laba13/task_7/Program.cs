using System;
using System.Linq;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<int> Rating { get; set; }

    public Student(string firstName, string lastName, List<int> rating)
    {
        FirstName = firstName;
        LastName = lastName;
        Rating = rating;
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
            var rating = parts.Skip(2).Select(int.Parse).ToList();
            students.Add(new Student(firstName, lastName, rating));
        }

        var result = students.Where(s => s.Rating.Contains(6));

        foreach (var student in result)
        {
            Console.WriteLine(student);
        }
    }
}