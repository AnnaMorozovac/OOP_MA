using System;
using System.Collections.Generic;

/*
Cat Pesho 1,1 Home Persian
Vegetable 4
End

Tiger Typcho 167,7 Asia Bengal
Vegetable 1
Dog Doncho 500 Street
Vegetable 150
End

Mouse Jerry 0,5 Anywhere
Fruit 1000
Owl Toncho 2,5 30
Meat 5
End

*/

abstract class Food
{
    public int Quantity { get; }

    protected Food(int quantity)
    {
        Quantity = quantity;
    }
}

class Vegetable : Food { public Vegetable(int q) : base(q) { } }
class Fruit : Food { public Fruit(int q) : base(q) { } }
class Meat : Food { public Meat(int q) : base(q) { } }
class Seeds : Food { public Seeds(int q) : base(q) { } }

abstract class Animal
{
    public string Name { get; }
    public double Weight { get; protected set; }
    public int FoodEaten { get; protected set; }

    protected Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public abstract string MakeSound();
    public abstract string Eat(Food food);
}

abstract class Bird : Animal
{
    public double WingSize { get; }

    protected Bird(string name, double weight, double wingSize)
        : base(name, weight)
    {
        WingSize = wingSize;
    }

    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {WingSize}, {Weight:F2}, {FoodEaten}]";
    }
}

class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    public override string MakeSound() => "Hoot hoot";

    public override string Eat(Food food)
    {
        if (food is Meat)
        {
            Weight += 0.25 * food.Quantity;
            FoodEaten += food.Quantity;
            return null;
        }
        else
        {
            return $"{GetType().Name} does not eat {food.GetType().Name}!";
        }
    }
}

class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    public override string MakeSound() => "Cluck";

    public override string Eat(Food food)
    {
        Weight += 0.35 * food.Quantity;
        FoodEaten += food.Quantity;
        return null;
    }
}

abstract class Mammal : Animal
{
    public string LivingRegion { get; }

    protected Mammal(string name, double weight, string livingRegion)
        : base(name, weight)
    {
        LivingRegion = livingRegion;
    }

    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {Weight:F2}, {LivingRegion}, {FoodEaten}]";
    }
}

class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    public override string MakeSound() => "Squeak";

    public override string Eat(Food food)
    {
        if (food is Vegetable || food is Fruit)
        {
            Weight += 0.10 * food.Quantity;
            FoodEaten += food.Quantity;
            return null;
        }
        else
        {
            return $"{GetType().Name} does not eat {food.GetType().Name}!";
        }
    }
}

class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion)
       : base(name, weight, livingRegion)
    {
    }

    public override string MakeSound() => "Woof!";

    public override string Eat(Food food)
    {
        if (food is Meat)
        {
            Weight += 0.40 * food.Quantity;
            FoodEaten += food.Quantity;
            return null;
        }
        else
        {
            return $"{GetType().Name} does not eat {food.GetType().Name}!";
        }
    }
}

abstract class Feline : Mammal
{
    public string Bread { get; }

    protected Feline(string name, double weight, string livingRegion, string bread)
       : base(name, weight, livingRegion)
    {
        Bread = bread;
    }

    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {Bread}, {Weight:F2}, {LivingRegion}, {FoodEaten}]";
    }
}

class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string bread) 
        : base(name, weight, livingRegion, bread)
    {
    }

    public override string MakeSound() => "Meow";

    public override string Eat(Food food)
    {
        if (food is Meat || food is Vegetable)
        {
            Weight += 0.30 * food.Quantity;
            FoodEaten += food.Quantity;
            return null;
        }
        else
        {
            return $"{GetType().Name} does not eat {food.GetType().Name}!";
        }
    }
}

class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string bread)
       : base(name, weight, livingRegion, bread)
    {
    }

    public override string MakeSound() => "ROAR!!!";

    public override string Eat(Food food)
    {
        if (food is Meat)
        {
            Weight += 1.00 * food.Quantity;
            FoodEaten += food.Quantity;
            return null;
        }
        else
        {
            return $"{GetType().Name} does not eat {food.GetType().Name}!";
        }
    }
}

class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>();
        List<string> output = new List<string>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] animalParts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] foodParts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string animalType = animalParts[0];
            string name = animalParts[1];
            double weight = double.Parse(animalParts[2]);

            Animal animal = null;
            switch (animalType)
            {
                case "Cat":
                    animal = new Cat(name, weight, animalParts[3], animalParts[4]);
                    break;
                case "Tiger":
                    animal = new Tiger(name, weight, animalParts[3], animalParts[4]);
                    break;
                case "Dog":
                    animal = new Dog(name, weight, animalParts[3]);
                    break;
                case "Mouse":
                    animal = new Mouse(name, weight, animalParts[3]);
                    break;
                case "Owl":
                    animal = new Owl(name, weight, double.Parse(animalParts[3]));
                    break;
                case "Hen":
                    animal = new Hen(name, weight, double.Parse(animalParts[3]));
                    break;
            }

            string foodType = foodParts[0];
            int quantity = int.Parse(foodParts[1]);
            Food food;
            if (foodType == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (foodType == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else
            {
                food = null;
            }

            output.Add(animal.MakeSound());
            string warning = animal.Eat(food);
            if (warning != null)
            {
                output.Add(warning);
            }
            animals.Add(animal);
        }

        foreach (var line in output)
        {
            Console.WriteLine(line);
        }

        foreach (var a in animals)
        {
            Console.WriteLine(a);
        }
    }
}