using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Predicate<string> lenght = name => name.Length <= n;

        var result = names.Where(x => lenght(x));

        foreach (var name in result)
        {
            Console.WriteLine(name);
        }

    }
}