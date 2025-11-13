using System;
using System.Collections.Generic;
using System.Collections;

class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name} {Age}";
    }
}

class NameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (x == null || y == null) return 0;

        int lenghCompare = x.Name.Length.CompareTo(y.Name.Length);
        if (lenghCompare != 0)
            return lenghCompare;

        char firstX = char.ToLower(x.Name[0]);
        char firstY = char.ToLower(y.Name[0]);
        return firstX.CompareTo(firstY);
    }
}

class AgeComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (x == null || y == null) return 0;
        return x.Age.CompareTo(y.Age);
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var nameSet = new SortedSet<Person>(new NameComparator());
        var ageSet = new SortedSet<Person>(new AgeComparator());

        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split();
            string name = parts[0];
            int age = int.Parse(parts[1]);

            var person = new Person(name, age);
            nameSet.Add(person);
            ageSet.Add(person);
        }

        foreach (var person in nameSet)
        {
            Console.WriteLine(person);
        }
        foreach (var person in ageSet)
        {
            Console.WriteLine(person);
        }
    }
}