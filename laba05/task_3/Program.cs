using System;
using System.Collections.Generic;

class Dough
{
    private string flour;
    private string bakingTech;
    private double weight;

    public Dough(string flour, string bakingTech, double weight)
    {
        this.Flour = flour;
        this.BakingTech = bakingTech;
        this.Weight = weight;
    }

    public string Flour
    {
        get { return flour; }
        set
        {
            string lower = value.ToLower();
            if (lower != "white" && lower != "wholegrain")
            {
                throw new ArgumentException("Wrong dough theme");
            }
            flour = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("The weight must be in the range of 1 to 200.");
            }
            weight = value;
        }
    }

    public string BakingTech
    {
        get { return bakingTech; }
        set
        {
            string lower = value.ToLower();
            if (lower != "crispy" && lower != "chewy" && lower != "homemade")
            {
                throw new ArgumentException("Wrong dough theme");
            }
            bakingTech = value;
        }
    }

    public double Calories()
    {
            double flourM = 1.0;
            if (flour.ToLower() == "white")
            {
                flourM = 1.5;
            }
            if (flour.ToLower() == "wholegrain")
            {
                flourM = 1.0;
            }           

            double bakingM = 1.0;
            if (bakingTech.ToLower() == "crispy")
            {
                bakingM = 0.9;
            }
            if (bakingTech.ToLower() == "chewy")
            {
                bakingM = 1.1;
            }
            if (bakingTech.ToLower() == "homemade")
            {
                bakingM = 1.0;
            }

            return (2 * Weight) * flourM * bakingM;
    }
}

class Topping
{
    private string type;
    private double weight;

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public string Type
    {
        get { return type; }
        set
        {
            string lower = value.ToLower();
            if (lower != "meat" && lower != "veggies" && lower != "cheese" && lower != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{Type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public double Calories()
    {
            double mod = 1.0;
            if (Type.ToLower() == "meat")
            {
                mod = 1.2;
            }
            else if (Type.ToLower() == "veggies")
            {
                mod = 0.8;
            }
            else if (Type.ToLower() == "cheese")
            {
                mod = 1.1;
            }
            else if (Type.ToLower() == "sauce")
            {
                mod = 0.9;
            }

            return (2 * Weight) * mod;
    }
}

class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings = new List<Topping>();

    public Pizza(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name must contain 1 to 15 characters");
            }
            name = value;
        }
    }

    public void SetDough(Dough dough)
    {
        this.dough = dough;
    }

    public void AddTopping(Topping topping)
    {
        if (toppings.Count >= 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10]");
        }
        toppings.Add(topping);
    }

    public double TotalCalories()
    {
            double sum = dough.Calories();
            for (int i = 0; i < toppings.Count; i++)
            {
                sum += toppings[i].Calories();
            }
            return sum;
    }

    public int ToppingCount
    {
        get { return toppings.Count; }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string[] pizzaInput = Console.ReadLine().Split();
            Pizza pizza = new Pizza(pizzaInput[1]);

            string[] doughInput = Console.ReadLine().Split();
            Dough dough = new Dough(doughInput[1], doughInput[2], double.Parse(doughInput[3]));
            pizza.SetDough(dough);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] parts = input.Split();
                Topping topping = new Topping(parts[1], double.Parse(parts[2]));
                pizza.AddTopping(topping);
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():F2} calories");
        }
        catch (ArgumentException er)
        {
            Console.WriteLine(er.Message);
        }
    }
}