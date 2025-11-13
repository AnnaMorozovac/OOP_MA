using System;
class Program
{
    static void Main()
    {
        int n, number, nDigit;
        Console.WriteLine("Enter number: ");
        number = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter n: ");
        n = int.Parse(Console.ReadLine());

        nDigit = (number / (int)Math.Pow(10, n - 1)) % 10;

        if (n > number.ToString().Length)
        {
            Console.WriteLine("-");
        }
        else
        {
            Console.WriteLine($"Number =  {nDigit}");
        }
    }

}