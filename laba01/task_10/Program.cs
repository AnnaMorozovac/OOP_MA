using System;
class Program
{
    static void Main()
    {
        int n, lastDigit;
        Console.WriteLine("Enter numbers: ");
        n = int.Parse(Console.ReadLine());

        lastDigit = n % 10;

        Console.WriteLine(lastDigit);
    }

}