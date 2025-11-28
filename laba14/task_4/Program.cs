using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Predicate<int> isEven = x => x % 2 == 0;

        int[] range = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int rangeDown = range[0];
        int rangeUp = range[1];
        int[] numbers = Enumerable.Range(rangeDown, rangeUp - rangeDown + 1).ToArray();

        string command = Console.ReadLine();
        int[] selected;

        if(command == "odd") { selected = numbers.Where(n => !isEven(n)).ToArray(); }
        else if(command == "even") { selected = numbers.Where(n => isEven(n)).ToArray(); }
        else { throw new ArgumentException("Invalid command"); }

        Array.ForEach(selected, item => Console.Write($"{item} "));
    }
}