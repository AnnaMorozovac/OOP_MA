using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Введiть n: ");
        int n = int.Parse(Console.ReadLine());

        bool[] primes = new bool[n+1];
        for(int i=0; i<=n; i++)
        {
            primes[i] = true;
        }

        primes[0] = false;
        primes[1] = false;

        for(int p=2; p * p <= n; p++)
        {
            if (primes[p])
            { 
                for(int ii=p*2; ii<=n; ii += p)
                {
                    primes[ii] = false;
                }
            }
        }

        Console.Write("Простi числа: ");
        for(int p=2; p<n; p++)
        {
            if (primes[p])
            {
                Console.Write(p + " ");
            }
        }

    }
}