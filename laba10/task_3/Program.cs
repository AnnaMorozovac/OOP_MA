using System;
using System.Collections.Generic;

class Person : IComparable<Person>
{
    private string name;
    private int age;
    private string towm;

    public Person(string name, int age, string towm)
    {
        Name = name;
        Age = age;
        Towm = towm;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (value == null)
                throw new ArgumentNullException("Name cannot be null");
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value <= 0)
                throw new ArgumentNullException("Age must be positive");
            age = value;
        }
    }

    public string Towm
    {
        get { return towm; }
        set
        {
            if (value == null)
                throw new ArgumentNullException("Towm cannot be null");
            towm = value;
        }
    }

    public int CompareTo(Person other)
    {
        if (other == null) return 1;

        int nameResult = Name.CompareTo(other.Name);
        if (nameResult != 0) return nameResult;

        int ageResult = Age.CompareTo(other.Age);
        if (ageResult != 0) return ageResult;

        return Towm.CompareTo(other.Towm);
    }
}

class Program
{
    static void Main()
    {
        var people = new List<Person>();
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] parts = input.Split();
            string name = parts[0];
            int age = int.Parse(parts[1]);
            string town = parts[2];

            people.Add(new Person(name, age, town));
        }

        int targetIndex = int.Parse(Console.ReadLine()) - 1;
        Person targetPerson = people[targetIndex];

        int equalCount = 0;

        foreach (var person in people)
        {
            if (person.CompareTo(targetPerson) == 0)
                equalCount++;
        }

        if (equalCount == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            int total = people.Count;
            int notEqual = total - equalCount;
            Console.WriteLine($"{equalCount} {notEqual} {total}");
        }
    }
}