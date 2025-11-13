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
        int n = int.Parse(Console.ReadLine());
        List<string> result = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int intValue))
            {
                var intBox = new Box<int>(intValue);
                result.Add(intBox.ToString());
            }
            else
            {
                var stringBox = new Box<string>(input);
                result.Add(stringBox.ToString());
            }
        }

        foreach (string line in result)
        {
            Console.WriteLine(line);
        }

    }
}