using System;

class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public Person() : this(1) { }

    public Person(int age) : this("Gosho", age) { }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}

class Family
{
    private Person oldest;

    public void AddMember(Person member)
    {
        if (oldest == null || member.Age > oldest.Age)
        {
            oldest = member;
        }
    }

    public Person GetOldest()
    {
        return oldest;
    }
}

class Program
{
    static void Main()
    {
        Family family = new Family();

        Console.Write("Введiть кiлькiсть людей: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Iм'я люидини: ");
            string name = Console.ReadLine();

            Console.Write("Вiк люидини: ");
            int age = int.Parse(Console.ReadLine());

            Person person = new Person(name, age);
            family.AddMember(person);
        }

        Person oldest = family.GetOldest();
        Console.WriteLine($"Найстарший член родини: {oldest.Name}, {oldest.Age}");
    }
}
