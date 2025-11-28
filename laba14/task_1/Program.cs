using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void GetNames(List<string> names)
    {
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
    static void Main()
    {
        Action<List<string>> namesAction = GetNames;
        var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

        namesAction.Invoke(names);
    }
}