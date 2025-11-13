using System;
class Program
{
    static void Main()
    {
        int n;
        int factorial = 1;

        Console.WriteLine("Enter n: ");
        n = int.Parse(Console.ReadLine());

        for(int i=2; i<=n; i++)
        {
            factorial *= i;
        }

        Console.WriteLine($"Factorial = {factorial}");
    }

}