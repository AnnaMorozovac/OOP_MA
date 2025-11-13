using System;
using System.Collections;
using System.Collections.Generic;

public class CustonList<T> : IEnumerable<T>
{
    private List<T> list = new List<T>();

    public void Adds(T element)
    {
        list.Add(element);
    }

    public T Remove(int index)
    {
        T remove = list[index];
        list.RemoveAt(index);
        return remove;
    }

    public bool Contains(T element)
    {
        return list.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        T temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;
        foreach (var line in list)
        {
            if (string.Compare(line.ToString(), element.ToString()) > 0)
                count++;
        }

        return count;
    }

    public T Max()
    {
        T tempMax = list[0];
        foreach (var line in list)
        {
            if (string.Compare(line.ToString(), tempMax.ToString()) > 0)
                tempMax = line;
        }
        return tempMax;
    }

    public T Min()
    {
        T tempMin = list[0];
        foreach (var line in list)
        {
            if (string.Compare(line.ToString(), tempMin.ToString()) < 0)
                tempMin = line;
        }

        return tempMin;
    }

    public void Print()
    {
        foreach(var line in list)
        {
            Console.WriteLine(line);
        }
    }

    public void Sort()
    {
        list.Sort((a, b) => string.Compare(a.ToString(), b.ToString(), StringComparison.Ordinal));
    }

    public IEnumerator<T> GetEnumerator()
    {
        return list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public static class Sorter
{
    public static void Sort<T>(CustonList<T> list)
    {
        list.Sort();
    }
}

public class Program
{
    public static void Main()
    {
        CustonList<string> list = new CustonList<string>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END") break;

            string[] parts = input.Split();
            string command = parts[0];

            switch (command)
            {
                case "Add":
                    list.Adds(parts[1]);
                    break;
                case "Remove":
                    list.Remove(int.Parse(parts[1]));
                    break;
                case "Contains":
                    Console.WriteLine(list.Contains(parts[1]));
                    break;
                case "Swap":
                    int index1 = int.Parse(parts[1]);
                    int index2 = int.Parse(parts[2]);
                    list.Swap(index1, index2);
                    break;
                case "Greater":
                    Console.WriteLine(list.CountGreaterThan(parts[1]));
                    break;
                case "Max":
                    Console.WriteLine(list.Max());
                    break;
                case "Min":
                    Console.WriteLine(list.Min());
                    break;
                case "Print":
                    list.Print();
                    break;
                case "Sort":
                    Sorter.Sort(list);
                    break;
            }
        }
    }
}