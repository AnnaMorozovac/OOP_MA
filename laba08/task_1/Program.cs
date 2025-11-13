using System;
using System.Collections.Generic;

/*
Car 15 0,3
Truck 100 0,9
4
Drive Car 9
Drive Car 30
Refuel Car 50
Drive Truck 10

Car 30,4 0,4
Truck 99,34 0,9
5
Drive Car 500
Drive Car 13,5
Refuel Truck 10,300
Drive Truck 56,2
Refuel Car 100,2
*/

abstract class Vehicle
{
    public double FuelQuantity { get; protected set; }
    public double FuelConsumption { get; protected set; }

    protected Vehicle(double fuelQuantity, double fuelConsumption)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    public abstract string Drive(double distance);

    public virtual void Refuel(double liters)
    {
        FuelQuantity += liters;
    }
}

class Car : Vehicle
{
    private const double Air = 0.9;

    public Car(double fuelQuantity, double fuelConsumption) 
        : base(fuelQuantity, fuelConsumption + Air)
    {
    }

    public override string Drive(double distance)
    {
        double neededFuel = distance * FuelConsumption;

        if (neededFuel <= FuelQuantity)
        {
            FuelQuantity -= neededFuel;
           return $"Car travvelled {distance} km";
        }
        else
        {
            return $"Car needs refueling";
        }
    }
}

class Truck : Vehicle
{
    private const double Air = 1.6;

    public Truck(double fuelQuantity, double fuelConsumption)
        : base(fuelQuantity, fuelConsumption + Air)
    {
    }

    public override string Drive(double distance)
    {
        double neededFuel = distance * FuelConsumption;

        if (neededFuel <= FuelQuantity)
        {
            FuelQuantity -= neededFuel;
            return $"Truck travvelled {distance} km";
        }
        else
        {
            return $"Truck needs refueling";
        }
    }

    public override void Refuel(double liters)
    {
        FuelQuantity += liters * 0.95;
    }
}

class Program
{
    static void Main()
    {
        string[] carInfo = Console.ReadLine().Split();
        string[] truckInfo = Console.ReadLine().Split();

        Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
        Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

        int n = int.Parse(Console.ReadLine());
        List<string> result = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string[] commandParts = Console.ReadLine().Split();
            string command = commandParts[0];
            string vehicleType = commandParts[1];

            if (command == "Drive")
            {
                double distance = double.Parse(commandParts[2]);

                if (vehicleType == "Car")
                    result.Add(car.Drive(distance));
                else if (vehicleType == "Truck")
                    result.Add(truck.Drive(distance));
            }
            else if (command == "Refuel")
            {
                double liters = double.Parse(commandParts[2]);

                if (vehicleType == "Car")
                    car.Refuel(liters);
                else if (vehicleType == "Truck")
                    truck.Refuel(liters);
            }
        }

        Console.WriteLine();
        foreach (string message in result)
            Console.WriteLine(message);

        Console.WriteLine($"Car: {car.FuelQuantity:F2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
    }
}