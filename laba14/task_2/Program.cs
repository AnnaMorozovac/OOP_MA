using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Action<List<string>> sirAction = list =>
        {
            foreach (var items in list)
            {
                Console.WriteLine($"Sir {items}");
            }
        };

        var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        sirAction.Invoke(names);
    }
}