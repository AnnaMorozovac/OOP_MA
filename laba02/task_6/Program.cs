using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Введiть числовий масив: ");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int start = 0;
        int len = 1;

        int start1 = 0;
        int len1 = 1;

        for(int i=1; i<array.Length; i++)
        {
            if (array[i] == array[i-1])
            {
                len++;
            }
            else
            {
                start = i;
                len = 1;
            }

            if(len > len1)
            {
                len1 = len;
                start1 = start;
            }
        }

        Console.Write("Найдовша послiдовнiсть: ");
        for(int i=start1; i<start1+len1; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}