using System;
class Program
{
    static void Main()
    {
        int a, b, c;
        Console.WriteLine("Enter a: ");
        a = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter b: ");
        b = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter c: ");
        c = int.Parse(Console.ReadLine());

        float average = (a + b + c) / 3f;

        Console.WriteLine(average);
    }

}
