using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Func<int, int> add = x => x + 1;
        Func<int, int> multiply = x => x * 2;
        Func<int, int> subtract = x => x - 1;
        Action<int[]> print = array => Array.ForEach(array, item => Console.WriteLine($"{item}"));

        var numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            switch (command)
            {
                case "add": numbers = numbers.Select(add).ToArray(); break;
                case "multiply": numbers = numbers.Select(multiply).ToArray(); break;
                case "subtract": numbers = numbers.Select(subtract).ToArray(); break;
                case "print": print.Invoke(numbers); Console.WriteLine(); break;
                default: throw new ArgumentException("invalid command!"); break;
            }
        }
    }
}