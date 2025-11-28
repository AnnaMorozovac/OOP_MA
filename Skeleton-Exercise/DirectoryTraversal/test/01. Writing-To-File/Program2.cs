using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Food
{
    public abstract int Happiness { get; }
}

public class Cram : Food { public override int Happiness => 2; }
public class Lembas : Food { public override int Happiness => 3; }
public class Apple : Food { public override int Happiness => 1; }
public class Melon : Food { public override int Happiness => 1; }
public class HoneyCake : Food { public override int Happiness => 5; }
public class Mushrooms : Food { public override int Happiness => -10; }
public class OtherFood : Food { public override int Happiness => -1; }

public class FoodFactory
{
    public static Food CreatFood(string name)
    {
        switch (name.ToLower())
        {
            case "cram": return new Cram();
            case "lembas": return new Lembas();
            case "apple": return new Apple();
            case "melon": return new Melon();
            case "honeycake": return new HoneyCake();
            case "mushrooms": return new Mushrooms();
            default: return new OtherFood();
        }
    }
}

public abstract class Mood
{
    public abstract string Name { get; }
}

public class Angry : Mood { public override string Name => "Angry"; }
public class Sad : Mood { public override string Name => "Sad"; }
public class Happy : Mood { public override string Name => "Happy"; }
public class VeryHappy : Mood { public override string Name => "VeryHappy"; }

public class MoodFactory
{
    public static Mood CreatMood(int happiness)
    {
        if (happiness < -5) return new Angry();
        if (happiness >= -5 && happiness <= 0) return new Sad();
        if (happiness >= 1 && happiness <= 15) return new Happy();
        return new VeryHappy();
    }
}

public class Gandalf
{
    private List<Food> foods = new List<Food>();

    public void Eat(string[] foodName)
    {
        for (int i = 0; i < foodName.Length; i++)
        {
            foods.Add(FoodFactory.CreatFood(foodName[i]));
        }
    }

    public int GetHappiness()
    {
        int total = 0;
        for (int i = 0; i < foods.Count; i++)
        {
            total += foods[i].Happiness;
        }

        return total;
    }

    public string GetMood()
    {
        return MoodFactory.CreatMood(GetHappiness()).Name;
    }
}

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string[] foodNames = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Gandalf gandalf = new Gandalf();
        gandalf.Eat(foodNames);

        Console.WriteLine(gandalf.GetHappiness());
        Console.WriteLine(gandalf.GetMood());
    }
}