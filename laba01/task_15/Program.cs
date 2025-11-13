using System;
class Program
{
    static void Main()
    {
        double a, b, c;
        int product = 0;

        Console.WriteLine("Enter a: ");
        a = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter b: ");
        b = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter c: ");
        c = double.Parse(Console.ReadLine());

        if (a < 0) product++;
        if (b < 0) product++;
        if (c < 0) product++;

        if(product % 2 == 0)
        {
            Console.WriteLine("Positive");
        }
        else
        {
            Console.WriteLine("Negative");
        }

        /*if (product == 0 || product == 2)
        {
            Console.WriteLine("Positive");
        }
        if(product == 1 || product == 3)
        {
            Console.WriteLine("Negative");
        }*/

    }

}