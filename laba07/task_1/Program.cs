using System;
using System.Linq;

public interface ICallable
{
    void Call(string number);
}

public interface IBrowsable
{
    void Browse(string url);
}

public class Smartphone : ICallable, IBrowsable
{
    public void Call(string number)
    {
        if (!number.All(char.IsDigit))
        {
            Console.WriteLine("Invalid number");
        } 
        else
        {
            Console.WriteLine($"Calling... {number}");
        }
    }

    public void Browse(string url)
    {
        if (url.Any(char.IsDigit))
        {
            Console.WriteLine("Invalid URL");
        }
        else
        {
            Console.WriteLine($"Browsing: {url}");
        }
    }
}

public class Program
{
    public static void Main()
    {
        string[] phoneNumber = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Smartphone smartphone = new Smartphone();

        for (int i = 0; i < phoneNumber.Length; i++)
        {
            smartphone.Call(phoneNumber[i]);
        }

        for (int i = 0; i < urls.Length; i++)
        {
            smartphone.Browse(urls[i]);
        }
    }
}