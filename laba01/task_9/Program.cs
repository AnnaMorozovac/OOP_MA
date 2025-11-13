using System;
class Program
{
    static void Main()
    {
        double a, b, h;
        Console.WriteLine("Enter a: ");
        a = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter b: ");
        b = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter h: ");
        h = double.Parse(Console.ReadLine());

        double area = ((a + b) / 2) * h;

        Console.WriteLine($"Area = {area}");
    }

}