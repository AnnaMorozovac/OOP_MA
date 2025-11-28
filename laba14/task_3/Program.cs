using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Func<int[], int> minFun = numbers => numbers.Min();

        var num = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        Console.WriteLine(minFun(num));
    }
}