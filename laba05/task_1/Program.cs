using System;

class Chiken
{
    private string name;
    private int age;

    private const int MinAge = 0;
    private const int MaxAge = 15;

    public Chiken(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Iм'я не може бути порожнiм");
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value < MinAge || value > MaxAge)
                throw new ArgumentException("Вiк повинен бути вiд 0 до 15");
            age = value;
        }
    }

    private double CalculateProductPerDay()
    {
        switch (this.Age)
        {
            case 1:
            case 2:
            case 3:
                return 1.5;
            case 4:
            case 5:
            case 6:
            case 7:
                return 2;
            case 8:
            case 9:
            case 10:
            case 11:
                return 1;
            default:
                return 0.75;
        }
    }

    public double ProductPerDay
    {
        get { return CalculateProductPerDay(); }
    }

}

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введiть iм'я: ");
            string name = Console.ReadLine();

            Console.Write("Введiть вiк: ");
            int age = int.Parse(Console.ReadLine());

            Chiken chiken = new Chiken(name, age);

            Console.Write($"Курка {chiken.Name} (вiк {chiken.Age}) може виробляти {chiken.ProductPerDay} яєць на день");
        }
        catch (ArgumentException er)
        {
            Console.WriteLine(er.Message);
        }
    }
}