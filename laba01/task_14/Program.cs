using System;
class Program
{
    static void Main()
    {
        int a, b, c;
        int max;

        Console.WriteLine("Enter a: ");
        a = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter b: ");
        b = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter c: ");
        c = int.Parse(Console.ReadLine());

        max = a;
        if(b > max)
        {
            max = b;
        }
        if (c > max)
        {
            max = c;
        }

        Console.WriteLine($"Max: {max}");
    }

}