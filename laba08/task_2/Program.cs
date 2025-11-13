using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

/*
Car 30 0,04 70
Truck 100 0,5 300
Bus 40 0,3 150
8
Refuel Car -10
Refuel Truck 0
Refuel Car 10
Refuel Car 300
Drive Bus 10
Refuel Bus 1000
DriveEmpty Bus 100
Refuel Truck 1000
*/

abstract class Vehicle
{
    public double FuelQuantity { get; protected set; }
    public double FuelConsumption { get; protected set; }
    public double TankCapacity { get; }

    protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        if (fuelQuantity > tankCapacity)
            fuelQuantity = 0;

        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
        TankCapacity = tankCapacity;
    }

    public virtual string Drive(double distance)
    {
        double neededFuel = distance * FuelConsumption;

        if (neededFuel > FuelQuantity)
            return $"{this.GetType().Name} needs refueling";

        FuelQuantity -= neededFuel;
        return $"{this.GetType().Name} travelled {distance} km";
    }

    public virtual string Refuel(double amount)
    {
        if (amount <= 0)
            return "Fuel must be a positive number";

        if (FuelQuantity + amount > TankCapacity)
            return $"Cannot fit {amount} fuel in the tank";

        FuelQuantity += amount;
        return null;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {FuelQuantity:F2}";
    }
}

class Car : Vehicle
{
    private const double Air = 0.9;

    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption + Air, tankCapacity)
    {
    }
}

class Truck : Vehicle
{
    private const double Air = 1.6;

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption + Air, tankCapacity)
    {
    }

    public override string Refuel(double amount)
    {
        if (amount <= 0)
            return "Fuel must be a positive number";

        double effective = amount * 0.95;
        if (FuelQuantity + effective > TankCapacity)
            return $"Cannot fit {amount} fuel in the tank";

        FuelQuantity += effective;
        return null;
    }
}

class Bus : Vehicle
{
    private const double Air = 1.4;

    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public string Drive(double distance, bool empty)
    {
        double extraConsumption;
        if (empty)
        {
            extraConsumption = 0;
        }
        else
        {
            extraConsumption = Air;
        }
        double neededFuel = distance * (FuelConsumption + extraConsumption);

        if (neededFuel > FuelQuantity)
            return $"{this.GetType().Name} needs refueling";

        FuelQuantity -= neededFuel;
        return $"{this.GetType().Name} travelled {distance} km";
    }

    public override string Drive(double distance)
    {
        return Drive(distance, false);
}
}

static class VehicleFactory
{
    public static Vehicle Create(string input)
    {
        string[] parts = input.Split();
        string type = parts[0];
        double fuel = double.Parse(parts[1]);
        double consumption = double.Parse(parts[2]);
        double capacity = double.Parse(parts[3]);

        switch (type)
        {
            case "Car":
                return new Car(fuel, consumption, capacity);
            case "Truck":
                return new Truck(fuel, consumption, capacity);
            case "Bus":
                return new Bus(fuel, consumption, capacity);
            default:
                throw new ArgumentException("Invalid vehicle type");
        }
    }
}

class Program
{
    static void Main()
    {
        Vehicle car = VehicleFactory.Create(Console.ReadLine());
        Vehicle truck = VehicleFactory.Create(Console.ReadLine());
        Vehicle bus = VehicleFactory.Create(Console.ReadLine());

        int n = int.Parse(Console.ReadLine());
        List<string> result = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string[] commandParts = Console.ReadLine().Split();
            string command = commandParts[0];
            string type = commandParts[1];

            try
            {
                if (command == "Drive")
                {
                    double distance = double.Parse(commandParts[2]);
                    if (type == "Car") result.Add(car.Drive(distance));
                    else if (type == "Truck") result.Add(truck.Drive(distance));
                    else if (type == "Bus")
                    {
                        result.Add(bus.Drive(distance));
                    }
                }
                else if (command == "DriveEmpty")
                {
                    double distance = double.Parse(commandParts[2]);

                    Bus currentBus = bus as Bus;
                    if (currentBus != null)
                    {
                        result.Add(currentBus.Drive(distance, true));
                    }
                    else
                    {
                        result.Add("Vehicle is not a Bus");
                    }
                }
                else if (command == "Refuel")
                {
                    double amount = double.Parse(commandParts[2]);
                    string res = null;

                    if (type == "Car") res = car.Refuel(amount);
                    else if (type == "Truck") res = truck.Refuel(amount);
                    else if (type == "Bus") res = bus.Refuel(amount);

                    if (res != null) result.Add(res);
                }
            }
            catch (Exception er)
            {
                result.Add(er.Message);
            }
        }

        Console.WriteLine();
        foreach (string message in result)
            Console.WriteLine(message);

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }
}