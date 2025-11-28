using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> guests = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        Dictionary<string, Predicate<string>> filters = new();

        string command;
        while ((command = Console.ReadLine()) != "Print")
        {
            var parts = command.Split(';');
            string action = parts[0];
            string filterType = parts[1];
            string parameter = parts[2];

            string key = $"{filterType};{parameter}";

            Predicate<string> predicate = filterType switch
            {
                "Starts with" => name => name.StartsWith(parameter),
                "Ends with" => name => name.EndsWith(parameter),
                "Length" => name => name.Length == int.Parse(parameter),
                "Contains" => name => name.Contains(parameter),
                _ => _ => false
            };

            if (action == "Add filter")
            {
                filters[key] = predicate;
            }
            else if (action == "Remove filter")
            {
                filters.Remove(key);
            }
        }

        foreach (var filter in filters.Values)
        {
            guests.RemoveAll(filter);
        }

        Console.WriteLine(string.Join(" ", guests));
    }
}