using System;
using System.Linq;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public Student(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} {Age}";
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
            int age = int.Parse(parts[2]);
            students.Add(new Student(firstName, lastName, age));
        }

        var result = students.Where(s => s.Age >= 18 && s.Age <= 24);

        foreach (var student in result)
        {
            Console.WriteLine(student);
        }
    }
}