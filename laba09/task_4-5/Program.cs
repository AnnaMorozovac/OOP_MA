using System;
using System.Collections.Generic;

public class Box<T>
{
    public T Value { get; }

    public Box(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return $"{Value.GetType().FullName}: {Value}";
    }

    public static void Swap(List<Box<T>> list, int index1, int index2)
    {
        Box<T> temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }
}

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Box<int>> intBoxes = new List<Box<int>>();
        List<Box<string>> stringBoxes = new List<Box<string>>();
        bool agri = true;

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int intValue))
            {
                intBoxes.Add(new Box<int>(intValue));
            }
            else
            {
                agri = false;
                stringBoxes.Add(new Box<string>(input));
            }
        }


        string[] ind = Console.ReadLine().Split();
        int firstIndex = int.Parse(ind[0]);
        int lastIndex = int.Parse(ind[1]);

        if (agri)
        {
            Box<int>.Swap(intBoxes, firstIndex, lastIndex);
        }
        else
        {
            Box<string>.Swap(stringBoxes, firstIndex, lastIndex);
        }

        if (agri)
        {
            foreach (var line in intBoxes)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            foreach (var line in stringBoxes)
            {
                Console.WriteLine(line);
            }
        }
    }
}