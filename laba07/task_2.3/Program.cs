using System;
using System.Collections.Generic;

public interface IBuyer
{
    string Name { get; }
    int Food { get; }
    void BuyFood();
}

public class Citizen : IBuyer
{
    public string Name { get; }
    public int Age { get; }
    public string Id { get; }
    public string Date { get; }
    public int Food { get; private set; }

    public Citizen(string name, int age, string id, string date)
    {
        Name = name;
        Age = age;
        Id = id;
        Date = date;
        Food = 0;
    }

    public void BuyFood()
    {
        Food += 10;
    }
}

public class Rebel : IBuyer
{
    public string Name { get; }
    public int Age { get; }
    public string Group { get; }
    public int Food { get; private set; }

    public Rebel(string name, int age, string group)
    {
        Name = name;
        Age = age;
        Group = group;
        Food = 0;
    }

    public void BuyFood()
    {
        Food += 5;
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<IBuyer> buyers = new List<IBuyer>();


        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 4)
            {
                string name = parts[0];
                int age = int.Parse(parts[1]);
                string id = parts[2];
                string date = parts[3];
                buyers.Add(new Citizen(name, age, id, date));
            }
            else if (parts.Length == 3)
            {
                string name = parts[0];
                int age = int.Parse(parts[1]);
                string group = parts[2];
                buyers.Add(new Rebel(name, age, group));
            }
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            for (int i = 0; i < buyers.Count; i++)
            {
                if (buyers[i].Name == input)
                {
                    buyers[i].BuyFood();
                    break;
                }
            }
        }

        int total = 0;
        for (int i = 0; i < buyers.Count; i++)
        {
            total += buyers[i].Food;
        }

        Console.WriteLine(total);
    }
}