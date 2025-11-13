using System;
using System.Collections.Generic;

enum ItemType
{
    Gold,
    Gem,
    Cash,
    Other
}

abstract class Item
{
    public string Name { get; set; }
    public ItemType Type { get; protected set; }
    public long Amount { get; set; }

    public Item(string name, long amount)
    {
        Name = name;
        Amount = amount;
    }
}

class GoldItem : Item
{
    public GoldItem(string name, long amount) : base(name, amount)
    {
        Type = ItemType.Gold;
    }
}

class GemItem : Item
{
    public GemItem(string name, long amount) : base(name, amount)
    {
        Type = ItemType.Gem;
    }
}

class CashItem : Item
{
    public CashItem(string name, long amount) : base(name, amount)
    {
        Type = ItemType.Cash;
    }
}

class OtherItem : Item
{
    public OtherItem(string name, long amount) : base(name, amount)
    {
        Type = ItemType.Other;
    }
}

class Bag
{
    private long Capacity;
    private List<Item> items = new List<Item>();
    private long totalGold = 0;
    private long totalGems = 0;
    private long totalCash = 0;

    public Bag(long capacity)
    {
        Capacity = capacity;
    }

    public bool TryAdd(Item newItem)
    {
        if (newItem.Type == ItemType.Other)
        {
            return false;
        }

        long currentTotal = 0;
        for (int i = 0; i < items.Count; i++)
        {
            currentTotal += items[i].Amount;
        }

        if (currentTotal + newItem.Amount > Capacity)
        {
            return false;
        }

        if (newItem.Type == ItemType.Gem && (totalGems + newItem.Amount) > totalGold)
        {
            return false;
        }

        if (newItem.Type == ItemType.Cash && (totalCash + newItem.Amount) > totalGems)
        {
            return false;
        }

        Item existing = null;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Name.Equals(newItem.Name, StringComparison.OrdinalIgnoreCase))
            {
                existing = items[i];
                break;
            }
        }

        if (existing != null)
        {
            existing.Amount += newItem.Amount;
        }
        else
        {
            items.Add(newItem);
        }

        if (newItem.Type == ItemType.Gold) totalGold += newItem.Amount;
        if (newItem.Type == ItemType.Gem) totalGems += newItem.Amount;
        if (newItem.Type == ItemType.Cash) totalCash += newItem.Amount;

        return true;
    }

    public void Print()
    {
        List<ItemType> types = new List<ItemType> { ItemType.Gold, ItemType.Gem, ItemType.Cash };

        for (int t = 0; t < types.Count; t++)
        {
            ItemType currentType = types[t];
            List<Item> group = new List<Item>();
            long groupSum = 0;

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Type == currentType)
                {
                    group.Add(items[i]);
                    groupSum += items[i].Amount;
                }
            }

            if (group.Count > 0)
            {
                Console.WriteLine("<" + currentType + "> $" + groupSum);

               for (int i = 0; i < group.Count - 1; i++)
               {
                    for (int j = i + 1; j < group.Count; j++)
                    {
                        if (string.Compare(group[i].Name, group[j].Name) < 0)
                        {
                            Item temp = group[i];
                            group[i] = group[j];
                            group[j] = temp;
                        }
                    }
               }

                for (int i = 0; i < group.Count - 1; i++)
                {
                    for (int j = i + 1; j < group.Count; j++)
                    {
                        if (group[i].Name == group[j].Name && group[i].Amount > group[j].Amount)
                        {
                            Item temp = group[i];
                            group[i] = group[j];
                            group[j] = temp;
                        }
                    }
                }

                for (int i = 0; i < group.Count; i++)
                {
                    Console.WriteLine("##" + group[i].Name + " - " + group[i].Amount);
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Мiсткiсть мiшка: ");
        long capacity = long.Parse(Console.ReadLine());

        Console.WriteLine("Коштовностi: ");
        string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Bag bag = new Bag(capacity);
        for (int i = 0; i < input.Length; i += 2)
        {
            string name = input[i];
            long amount = long.Parse(input[i + 1]);

            Item item;
            if (name.ToLower() == "gold")
                item = new GoldItem(name, amount);
            else if (name.ToLower().EndsWith("gem") && name.Length >= 4)
                item = new GemItem(name, amount);
            else if (name.Length == 3)
                item = new CashItem(name, amount);
            else
                item = new OtherItem(name, amount);

            bag.TryAdd(item);
        }

        bag.Print();
    }
}