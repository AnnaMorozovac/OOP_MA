using System;
using System.Collections.Generic;
using System.Linq;

class Pet
{
    public string Name { get; }
    public int Age { get; }
    public string Kind { get; }

    public Pet(string name, int age, string kind)
    {
        Name = name;
        Age = age;
        Kind = kind; 
    }

    public override string ToString()
    {
        return $"{Name} {Age} {Kind}";
    }
}

class Clinic
{
    private Pet[] rooms;
    public string Name { get; }

    public Clinic(string name, int roomsCount)
    {
        if (roomsCount % 2 == 0)
            throw new ArgumentException("Invalid operation");

        Name = name;
        rooms = new Pet[roomsCount];
    }

    public bool Add(Pet pet)
    {
        int center = rooms.Length / 2;
        for (int i = 0; i < rooms.Length; i++)
        {
            int index = center - i;
            if (index >= 0 && rooms[index] == null)
            {
                rooms[index] = pet;
                return true;
            }

            index = center + i;
            if (index < rooms.Length && rooms[index] == null)
            {
                rooms[index] = pet;
                return true;
            }
        }
        return false;
    }
    public bool Release()
    {
        int center = rooms.Length / 2;

        for (int i = center; i < rooms.Length; i++)
        {
            if (rooms[i] != null)
            {
                rooms[i] = null;
                return true;
            }
        }

        for (int i = 0; i < center; i++)
        {
            if (rooms[i] != null)
            {
                rooms[i] = null;
                return true;
            }
        }

        return false;
    }


    public bool HasEmptyRooms()
    {
        foreach (var room in rooms)
        {
            if (room == null) return true;
        }
        return false;
    }

    public void Print()
    {
        for(int i=0; i<rooms.Length; i++)
        {
            Pet currentPet = rooms[i];
            if (currentPet == null)
            {
                Console.WriteLine("Room empty");
            }
            else
            {
                Console.WriteLine(currentPet.Name + " " + currentPet.Age + " " + currentPet.Kind);
            }
        } 
    }

    public void Print(int roomNumder)
    {
        int index = roomNumder - 1;
        Pet pet = rooms[index];

        if (pet == null)
        {
            Console.WriteLine("Room emprty");
        }
        else
        {
            Console.WriteLine(pet.Name + " " + pet.Age + " " + pet.Kind);
        }
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var pets = new Dictionary<string, Pet>();
        var clinics = new Dictionary<string, Clinic>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();

            try
            {
                switch (input[0])
                {
                    case "Create":
                        if (input[1] == "Pet")
                        {
                            string name = input[2];
                            int age = int.Parse(input[3]);
                            string kind = input[4];
                            pets[name] = new Pet(name, age, kind);
                        }
                        else if (input[1] == "Clinic")
                        {
                            string name = input[2];
                            int rooms = int.Parse(input[3]);
                            clinics[name] = new Clinic(name, rooms);
                        }
                        break;
                    case "Add":
                        string petName = input[1];
                        string clinicName = input[2];
                        if (!pets.ContainsKey(petName) || !clinics.ContainsKey(clinicName))
                            throw new ArgumentException("Invalid operation");

                        Console.WriteLine(clinics[clinicName].Add(pets[petName]));
                        break;
                    case "Release":
                        Console.WriteLine(clinics[input[1]].Release());
                        break;
                    case "HasEmptyRooms":
                        Console.WriteLine(clinics[input[1]].HasEmptyRooms());
                        break;
                    case "Print":
                        string clinic = input[1];
                        if (input.Length == 2)
                        {
                            clinics[clinic].Print();
                        }
                        else
                        {
                            int room = int.Parse(input[2]);
                            clinics[clinic].Print(room);
                        }
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid operation");
            }
        }
    }
}