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

    public Person()
    {
        Name = "Persho";
        Age = 20;
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}

class Program
{
    static void Main()
    {
        Person p1 = new Person();

        Person p2 = new Person("Gocho", 18);

        Person p3 = new Person { Name = "Stamat", Age = 43 };

        Console.WriteLine($"{p1.Name}, {p1.Age} year");
        Console.WriteLine($"{p2.Name}, {p2.Age} year");
        Console.WriteLine($"{p3.Name}, {p3.Age} year");
     }
}
