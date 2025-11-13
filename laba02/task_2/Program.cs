using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Введiть числовий масив: ");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Console.Write("Введiть кiлькiсть обертання: ");
        int k = int.Parse(Console.ReadLine());

        int n = array.Length;
        int[] suma = new int[n];

        for(int j=0; j<k; j++)
        {
            int last = array[n-1];
            for(int i=n-1; i>0; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = last;

            Console.Write($"rotated{j + 1}[]: ");
            for(int ii=0; ii<n; ii++)
            {
                Console.Write(array[ii] + " ");
            }
            Console.WriteLine(" ");

            for (int i=0; i<n; i++)
            {
                suma[i] += array[i];
            }

        }

        Console.Write($"sum[]: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(suma[i] + " ");
        }


    }
}

