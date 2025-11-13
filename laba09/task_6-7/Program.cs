using System;
using System.Collections.Generic;

public class Box<T>
{
    public T Value { get; }

    public Box(T value)
    {
        Value = value;
    }

    public static int CountGreaterThan(List<Box<T>> list, T element)
    {
        int count = 0;
        for(int i=0; i<list.Count; i++)
        {
            if (double.TryParse(list[i].Value.ToString(), out double numder1) &&
                double.TryParse(element.ToString(), out double numder2))
            {
                if (numder1 > numder2)
                    count++;
            }
            else
            {
                if (string.Compare(list[i].Value.ToString(), element.ToString()) > 0)
                    count++;
            }
        }

        return count;
    }
}

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var list = new List<Box<string>>();
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            list.Add(new Box<string>(input));
        }

        string compareElement = Console.ReadLine();
        Console.WriteLine(Box<string>.CountGreaterThan(list, compareElement));
    }
}