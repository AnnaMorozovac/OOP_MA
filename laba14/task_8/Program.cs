using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        Comparison<int> customComparator = (a, b) =>
        {
            if (a % 2 == 0 && b % 2 != 0) return -1;
            if (a % 2 != 0 && b % 2 == 0) return 1;

            return a.CompareTo(b);
        };

        numbers = numbers.OrderByDescending(n => n).ToArray();

        Console.WriteLine(string.Join(' ', numbers));
    }
}