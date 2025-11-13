using System;

class Program
{
    static void Main()
    {
        //hi php java csharp sql html css js 
        //hi php java js softuni nakov java learn 

        //hi php java xml csharp sql html css js 
        //nakov java sql html css js 

        //I love programming 
        //Learn Java or C# 

        Console.Write("Array 1: ");
        string[] array = Console.ReadLine().Split(' ');

        Console.Write("Array 2: ");
        string[] array2 = Console.ReadLine().Split(' ');

        int leftParth = 0;
        for(int i=0; i<array.Length && i<array2.Length; i++)
        {
            if (array[i] == array2[i])
                leftParth++;
            else
                break;
        }

        int rightParth = 0;
        for(int i=1; i<array.Length && i<array2.Length; i++)
        {
            if (array[array.Length - i] == array2[array2.Length - i])
                rightParth++;
            else
                break;
        }

        if (leftParth == 0 && rightParth == 0)
        {
            Console.WriteLine("Немає спiльних слiв злiва та спрва");
        }
        else
        {
            if (leftParth >= rightParth)
            {
                Console.WriteLine("Найбiльше спiльних слiв знаходиться злiва");
                for (int i = 0; i < leftParth; i++)
                {
                    Console.WriteLine(array[i] + " ");
                }
            }
            else
            {
                Console.WriteLine("Найбiльше спiльних слiв знаходиться зправа");
                for (int i = array.Length - rightParth; i < array.Length; i++)
                {
                    Console.WriteLine(array[i] + " ");
                }
            }
        }
    }


}
