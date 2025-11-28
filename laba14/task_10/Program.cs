using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> guests = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

        string command;
        while ((command = Console.ReadLine()) != "Party!")
        {
            string[] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string action = parts[0];
            string criteria = parts[1];
            string value = parts[2];

            Predicate<string> match = criteria switch
            {
                "StartsWith" => name => name.StartsWith(value),
                "EndsWith" => name => name.EndsWith(value),
                "Length" => name => name.Length == int.Parse(value),
                _ => throw new ArgumentException("Invalid criteria")
            };

            if (action == "Remove")
            {
                guests.RemoveAll(match);
            }
            else if (action == "Double")
            {
                var matches = guests.Where(name => match(name)).ToList();
                foreach (var m in matches)
                    guests.Add(m);
            }
        }

        if (guests.Count > 0)
        {
            Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
        }
        else
        {
            Console.WriteLine("Nobody is going to the party!");
        }
    }
}