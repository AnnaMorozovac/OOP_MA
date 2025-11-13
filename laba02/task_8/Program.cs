using System;
using System.Linq;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        Console.Write("Введiть числовий масив: ");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int maxCount = 0;
        int freq = array[0];

        for(int i=0; i<array.Length; i++)
        {
            int current = array[i];
            int currentCount = 0;
            for(int j=0; j<array.Length; j++)
            {
                if (array[j] == current)
                    currentCount++;
            }

            if(currentCount > maxCount)
            {
                maxCount = currentCount;
                freq = current;
            }

        }

        Console.Write($"Число {freq} зустрiчається найчастiше {maxCount} разiв");
    }
}