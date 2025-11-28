using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int n = int.Parse(Console.ReadLine());

        Predicate<int> divisibleByN = x => x % n == 0;

        var result = numbers.Reverse().Where(x => !divisibleByN(x)).ToArray();

        Console.WriteLine(string.Join(" ", result));
    }
}