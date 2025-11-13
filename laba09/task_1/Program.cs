using System;

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
}

public class Program
{
    public static void Main()
    {

        string input = Console.ReadLine();

        if (int.TryParse(input, out int intValue))
        {
            var intBox = new Box<int>(intValue);
            Console.WriteLine(intBox);
        }
        else
        {
            var stringBox = new Box<string>(input);
            Console.WriteLine(stringBox);
        }

    }
}