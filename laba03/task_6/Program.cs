using System;

class Engine
{
    public string Mobel;
    public int Power;
    public string Displac;
    public string Efficiency;

    public Engine(string mobel, int power)
    {
        Mobel = mobel;
        Power = power;
        Displac = "n/a";
        Efficiency = "n/a";
    }

    public Engine(string mobel, int power, string displac) 
        : this(mobel, power)
    {
        Displac = displac;
    }

    public Engine(string mobel, int power, string displac, string efficiuncy)
        : this(mobel, power, displac)
    {
        Efficiency = efficiuncy;
    }
}

class Car
{
    public string Model;
    public Engine Engine;
    public string Weight;
    public string Color;

    public Car(string model, Engine engine)
    {
        Model = model;
        Engine = engine;
        Weight = "n/a";
        Color = "n/a";
    }

    public Car(string model, Engine engine, string weight) 
        : this(model, engine)
    {
        Weight = weight;
    }

    public Car(string model, Engine engine, string weight, string color) 
        : this(model, engine, weight)
    {
        Color = color;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введiть кiлькiсть двигунiв: ");
        int n = int.Parse(Console.ReadLine());

        Engine[] engines = new Engine[n];
        for(int i=0; i<n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string model = parts[0];
            int power = int.Parse(parts[1]);

            if (parts.Length == 2)
                engines[i] = new Engine(model, power);
            else if (parts.Length == 3)
            {
                if (char.IsDigit(parts[2][0]))
                    engines[i] = new Engine(model, power, parts[2]);
                else
                    engines[i] = new Engine(model, power, "n/a", parts[2]);
            }
            else if (parts.Length == 4)
                engines[i] = new Engine(model, power, parts[2], parts[3]);
        }

        Console.Write("Введiть кiлькiсть машин: ");
        int m = int.Parse(Console.ReadLine());

        Car[] cars = new Car[m];
        for(int i=0; i<m; i++)
        {
            string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string model = parts[0];
            string engineModel = parts[1];

            Engine engine = null;
            for(int j=0; j<engines.Length; j++)
            {
                if (engines[j].Mobel == engineModel)
                {
                    engine = engines[j];
                    break;
                }
            }

            if (parts.Length == 2)
                cars[i] = new Car(model, engine);
            else if (parts.Length == 3)
            {
                if (char.IsDigit(parts[2][0]))
                    cars[i] = new Car(model, engine, parts[2]);
                else
                    cars[i] = new Car(model, engine, "n/a", parts[2]);
            }
            else if (parts.Length == 4)
                cars[i] = new Car(model, engine, parts[2], parts[3]);
        }

        for (int i=0; i<cars.Length; i++)
        {
            Console.WriteLine($"{cars[i].Model}: ");
            Console.WriteLine($"  {cars[i].Engine.Mobel}: ");
            Console.WriteLine($"    Power: {cars[i].Engine.Power}");
            Console.WriteLine($"    Displacement: {cars[i].Engine.Displac}");
            Console.WriteLine($"    Efficiency: {cars[i].Engine.Efficiency}");
            Console.WriteLine($"   Weight: {cars[i].Weight}");
            Console.WriteLine($"   Color: {cars[i].Color}");
        }
    }
}
