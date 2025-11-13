using System;
using System.Linq;
using System.Collections.Generic;

public interface IIdentifiable
{
    string Id { get; }
}

public class Human : IIdentifiable
{
    public string Name { get; }
    public int Age { get; }
    public string Id { get; }

    public Human(string name, int age, string id)
    {
        Name = name;
        Age = age;
        Id = id;
    }
}

public class Robot : IIdentifiable
{
    public string Model { get; }
    public string Id { get; }

    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }
}

class Program
{
    static void Main()
    {
        List<IIdentifiable> entries = new List<IIdentifiable>();
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 3)
            {
                string name = parts[0];
                int age = int.Parse(parts[1]);
                string id = parts[2];
                entries.Add(new Human(name, age, id));
            }
            else if (parts.Length == 2)
            {
                string model = parts[0];
                string id = parts[1];
                entries.Add(new Robot(model, id));
            }
        }

        string fakeId = Console.ReadLine();
        for (int i = 0; i < entries.Count; i++)
        {
            if (entries[i].Id.EndsWith(fakeId))
            {
                Console.WriteLine(entries[i].Id);
            }
        }
        Console.WriteLine("You are detained! To be shot!!!");
    }
}