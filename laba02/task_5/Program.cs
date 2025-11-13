using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Введiть символьний масив 1: ");
        string[] array1 = Console.ReadLine().Split(' ');

        Console.Write("Введiть символьний масив 2: ");
        string[] array2 = Console.ReadLine().Split(' ');

        string w1 = string.Join("", array1);
        string w2 = string.Join("", array2);

        int min = Math.Min(w1.Length, w2.Length);
        bool temp = true;

        for(int i=0; i<min; i++)
        {
            if (w1[i] < w2[i])
            {
                Console.WriteLine(w1);
                Console.WriteLine(w2);
                temp = false;
                break;
            } else if (w1[i] > w2[i])
            {
                Console.WriteLine(w2);
                Console.WriteLine(w1);
                temp = false;
                break;
            }
        }

        if (temp)
        {
            if(w1.Length < w2.Length)
            {
                Console.WriteLine(w1);
                Console.WriteLine(w2);
            } else if(w1.Length > w2.Length)
            {
                Console.WriteLine(w2);
                Console.WriteLine(w1);
            }
            else
            {
                Console.WriteLine(w1);
                Console.WriteLine(w2);
            }
        }

    }
}