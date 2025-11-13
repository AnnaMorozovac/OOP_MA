using System;
using System.Collections.Generic;
using System.Linq;

public class NameRegistry
{
    public static HashSet<string> usedNames = new HashSet<string>();
}

delegate void KingAttackEventHandler();

class King
{
    public string Name { get; }

    public King(string name)
    {
        if (NameRegistry.usedNames.Contains(name))
        {
            throw new ArgumentException($"{Name} is alresdy used!");
        }
        Name = name;
        NameRegistry.usedNames.Add(name);
    }

    public event KingAttackEventHandler? UnderAttack;

    public void Attack()
    {
        Console.WriteLine($"King {Name} is under attack!");
        UnderAttack?.Invoke();
    }
}

class RoyalGuard
{
    public string Name { get; }
    public bool IsAlive { get; private set; } = true;
    public int HitCount { get; private set; } = 0;
    public event Action<RoyalGuard>? Died;

    public RoyalGuard(string name)
    {
        if (NameRegistry.usedNames.Contains(name))
        {
            throw new ArgumentException($"{Name} is alresdy used!");
        }
        Name = name;
        NameRegistry.usedNames.Add(name);
    }

    public void OnKingAttacked()
    {
        if (IsAlive)
        {
            Console.WriteLine($"Royal Guard {Name} is defending!");
        }
    }

    public void TakeHit()
    {
        if (!IsAlive) return;

        HitCount++;
        if (HitCount >= 3)
        {
            IsAlive = false;
            Died?.Invoke(this);
        }
    }
}

class Footman
{
    public string Name { get; }
    public bool IsAlive { get; private set; } = true;
    public int HitCount { get; private set; } = 0;
    public event Action<Footman>? Died;

    public Footman(string name)
    {
        if (NameRegistry.usedNames.Contains(name))
        {
            throw new ArgumentException($"{Name} is alresdy used!");
        }
        Name = name;
        NameRegistry.usedNames.Add(name);
    }

    public void OnKingAttacked()
    {
        if (IsAlive)
        {
            Console.WriteLine($"Footman {Name} is panik!");
        }
    }

    public void TakeHit()
    {
        if (!IsAlive) return;

        HitCount++;
        if (HitCount >= 2)
        {
            IsAlive = false;
            Died?.Invoke(this);
        }
    }

}

class Program
{
    static void Main()
    {
        string kingName = Console.ReadLine();
        King king = new King(kingName);

        List<RoyalGuard> royalGuards = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(name => new RoyalGuard(name)).ToList();

        List<Footman> footmen = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(name => new Footman(name)).ToList();

        foreach (var guard in royalGuards)
        {
            king.UnderAttack += guard.OnKingAttacked;

            guard.Died += g =>
            {
                king.UnderAttack -= g.OnKingAttacked;
                royalGuards.Remove(g);
            };
        }

        foreach (var footman in footmen)
        {
            king.UnderAttack += footman.OnKingAttacked;

            footman.Died += f =>
            {
                king.UnderAttack -= f.OnKingAttacked;
                footmen.Remove(f);
            };
        }
            

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            if (command == "Attack King")
            {
                king.Attack();
            }
            else if (command.StartsWith("Kill "))
            {
                string nameToKill = command.Split()[1];

                var guard = royalGuards.Find(g => g.Name == nameToKill);
                if (guard != null)
                {
                    guard.TakeHit();
                    continue;
                }

                var footm = footmen.Find(f => f.Name == nameToKill);
                if (footm != null)
                {
                    footm.TakeHit();
                }
            }
        }
    }
}