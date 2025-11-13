using System;
using System.Collections.Generic;

class ListyIterator<T>
{
    private List<T> items;
    private int index;

    public ListyIterator(params T[] element)
    {
        items = new List<T>(element);
        index = 0;
    }

    public bool Move()
    {
        if (HasNext())
        {
            index++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        return index + 1 < items.Count;
    }

    public void Print()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Invalis Operation");
        }
        Console.WriteLine(items[index]);
    }
}

class Program
{
    static void Main()
    {
        ListyIterator<string> iterator = null;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END") break;

            string[] parts = input.Split();
            string command = parts[0];

            try
            {
                switch (command)
                {
                    case "Create":
                        if (parts.Length > 1)
                        {
                            iterator = new ListyIterator<string>(parts[1..]);
                        }
                        else
                        {
                            iterator = new ListyIterator<string>();
                        }
                        break;
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    case "Print":
                        iterator.Print();
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operation");
                        break;
                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
        }
    }
}