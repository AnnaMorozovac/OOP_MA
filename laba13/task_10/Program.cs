using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public string Name { get; set; }
    public int Group { get; set; }

    public Person(string name, int group)
    {
        Name = name;
        Group = group;
    }
}

class Program
{
    static void Main()
    {
        var persons = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = parts[0] + " " + parts[1];
            int group = int.Parse(parts[2]);
            persons.Add(new Person(name, group));
        }

        var result = from p in persons
                     group p by p.Group into g
                     orderby g.Key
                     select g;

        foreach (var group in result)
        {
            Console.WriteLine($"{group.Key} - {string.Join(", ", group.Select(p => p.Name))}");
        }
    }
}