using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int[] divisors = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                         .Where(x => x != 0).ToArray();

        Predicate<int> divisibleByAll = number =>
        {
            return divisors.All(divisor => number % divisor == 0);
        };

        var result = Enumerable.Range(1, N).Where(number => divisibleByAll(number)).ToArray();

        Console.WriteLine(string.Join(' ', result));
    }
}