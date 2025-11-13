using System;

class Car
{
    public string Model;
    public double FuelAmount;
    public double AmountOfKm;
    public double DistanceTraveled;

    public Car (string model, double fuelAmount, 
        double amountOfKm)
    {
        Model = model;
        FuelAmount = fuelAmount;
        AmountOfKm = amountOfKm;
        DistanceTraveled = 0;
    }

    public bool Drive(double distance)
    {
        double fuelNeed = distance * AmountOfKm;
        if(FuelAmount >= fuelNeed)
        {
            FuelAmount -= fuelNeed;
            DistanceTraveled += distance;
            return true;
        } 
         return false;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введiть кiлькiсть машин: ");
        int n = int.Parse(Console.ReadLine());

        Car[] cars = new Car[n];
        Console.WriteLine("Введiть данi машини: ");
        for(int i=0; i<n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ');
            string model = parts[0];
            double fuelAmount = double.Parse(parts[1]);
            double amountOfKm = double.Parse(parts[2]);

            cars[i] = new Car(model, fuelAmount, amountOfKm);
        }

        List<string> commands = new List<string>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End") break;
            commands.Add(input);
        }

        foreach(string commandLine in commands)
        {
            string[] parts = commandLine.Split(' ');
            string command = parts[0];
            string carModel = parts[1];
            double distance = double.Parse(parts[2]);

            if (command == "Drive")
            {
                for (int i = 0; i < cars.Length; i++)
                {
                    if (cars[i].Model == carModel)
                    {
                        bool success = cars[i].Drive(distance);
                        if (!success)
                        {
                            Console.WriteLine("Не достатньо палива для руху");
                        }
                        break;
                    }

                }
            }
        }

        for(int i=0; i<cars.Length; i++)
        {
            Console.WriteLine($"{cars[i].Model}; {cars[i].FuelAmount:F2}; {cars[i].DistanceTraveled}");
        }

    }
}