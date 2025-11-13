using System;
using System.Collections.Generic;
using System.Linq;

enum Light
{
    Red,
    Green, 
    Yellow
}

class TrafficLight
{
    public Light Color { get; private set; }

    public TrafficLight(string color)
    {
        Color = Enum.Parse<Light>(color);
    }

    public void Change()
    {
         Color = (Light)(((int)Color + 1) % 3);
    }

    public override string ToString()
    {
        return Color.ToString();
    }
}

class Program
{
    static void Main()
    {
        List<TrafficLight> lights = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(c => new TrafficLight(c)).ToList();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            foreach (var light in lights)
                light.Change();

            Console.WriteLine(string.Join(" ", lights));
        }
    }
}