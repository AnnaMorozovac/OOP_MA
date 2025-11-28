using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var gems = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var filters = new List<(string Type, int Value)>();

        string input;
        while ((input = Console.ReadLine()) != "Forge")
        {
            var parts = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0];
            string filterType = parts[1];
            int value = int.Parse(parts[2]);

            if (command == "Exclude")
                filters.Add((filterType, value));
            else if (command == "Reverse")
                filters.Remove((filterType, value));
        }

        Func<int, int, int, string, int, bool> shouldExclude = (left, current, right, type, val) => type switch
        {
            "Sum Left" => left + current == val,
            "Sum Right" => current + right == val,
            "Sum Left Right" => left + current + right == val,
            _ => false
        };

        var excludedIndexes = Enumerable.Range(0, gems.Length).Where(i => filters.Any(f =>
        {
            int left = i > 0 ? gems[i - 1] : 0;
            int right = i < gems.Length - 1 ? gems[i + 1] : 0;
            return shouldExclude(left, gems[i], right, f.Type, f.Value);
        })).ToHashSet();

        var result = gems.Where((x, i) => !excludedIndexes.Contains(i));
        Console.WriteLine(string.Join(" ", result));

    }
}