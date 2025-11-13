using System;
using System.Linq;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }

    public Student(string firstName, string lastName, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
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
            string phone = parts[2];
            students.Add(new Student(firstName, lastName, phone));
        }

        var result = students.Where(s => s.Phone.StartsWith("02") || s.Phone.StartsWith("+3592"));

        foreach (var student in result)
        {
            Console.WriteLine(student);
        }
    }
}