using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Введiть числовий масив: ");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int k = array.Length / 4;

        int[] firstK = new int[k];
        int[] lastK = new int[k];

        for(int i=0; i<k; i++)
        {
            firstK[i] = array[k - 1 - i];
            lastK[i] = array[array.Length - 1 - i];
        }

        int[] firstRow = new int[k * 2];
        for(int i=0; i<k; i++)
        {
            firstRow[i] = firstK[i];
            firstRow[k+i] = lastK[i];
        }

        int[] secondRow = new int[k * 2];
        for(int i=0; i < 2 * k; i++)
        {
            secondRow[i] = array[k + i];
        }

        int[] suma = new int[k * 2];
        for(int i=0; i < 2*k; i++)
        {
            suma[i] = firstRow[i] + secondRow[i];
        }

        Console.Write($"Suma: ");
        for (int i = 0; i < 2 * k; i++)
        {
            Console.Write(suma[i] + " ");
        }
    }
}