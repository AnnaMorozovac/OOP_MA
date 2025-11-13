using System;
using System.Linq;
using System.Collections.Generic;

public interface IIdentifiable
{
    string Id { get; }
}

public interface IBirthable
{
    string Date { get; }
}

public class Human : IIdentifiable, IBirthable
{
    public string Name { get; }
    public int Age { get; }
    public string Id { get; }
    public string Date { get; }

    public Human(string name, int age, string id, string date)
    {
        Name = name;
        Age = age;
        Id = id;
        Date = date;
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

public class Pet : IBirthable
{
    public string Name { get; }
    public string Date { get; }

    public Pet(string name, string date)
    {
        Name = name;
        Date = date;
    }
}

class Program
{
    static void Main()
    {
        List<IBirthable> birthables = new List<IBirthable>();
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts[0] == "Citizen")
            {
                string name = parts[1];
                int age = int.Parse(parts[2]);
                string id = parts[3];
                string date = parts[4];
                birthables.Add(new Human(name, age, id, date));
            }
            else if (parts[0] == "Pet")
            {
                string name = parts[1];
                string date = parts[2];
                birthables.Add(new Pet(name, date));
            }
        }
        string year = Console.ReadLine();
        Console.WriteLine();
        for (int i = 0; i < birthables.Count; i++)
        {
            if (birthables[i].Date.EndsWith(year))
            {
                Console.WriteLine(birthables[i].Date);
            }
        }
    }
}