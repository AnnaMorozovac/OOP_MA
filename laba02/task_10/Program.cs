using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Введiть числовий масив: ");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Console.Write("Введiть рiзницю: ");
        int difference = int.Parse(Console.ReadLine());

        int count = 0;

        for(int i=0; i<array.Length; i++)
        {
            for(int j=0; j<array.Length; j++)
            {
                if(i != j)
                {
                    int diff = array[i] - array[j];
                    if(diff == difference || diff == -difference)
                    {
                        count++;
                    }
                }    
            }
        }

        count /= 2;

        Console.WriteLine($"Пари елементiв з рiзницей {difference} -> {count}");
    }
}