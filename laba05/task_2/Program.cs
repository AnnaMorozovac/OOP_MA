using System;
using System.Collections.Generic;

class Product
{
    private string name;
    private decimal cost;

    public Product(string name, decimal cost)
    {
        Name = name;
        Cost = cost;
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

    public decimal Cost
    {
        get { return cost; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Грошi не можуть бути вiд'ємним числом");
            cost = value;
        }
    }
}

class Person
{
    private string name;
    private decimal money;
    private List<Product> bag = new List<Product>();
    private List<string> succMessages = new List<string>();
    private List<string> failMessages = new List<string>();

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
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

    public decimal Money
    {
        get { return money; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Грошi не можуть бути вiд'ємним числом");
            money = value;
        }
    }

    public void ByuProduct(Product p)
    {
        if (Money >= p.Cost)
        {
            Money -= p.Cost;
            bag.Add(p);
            succMessages.Add(Name + " bought " + p.Name);
        } 
        else
        {
            failMessages.Add(Name + " can`t afford " + p.Name);
        }
    }

    public void PrintMessages(bool printS)
    {
        List<string> messages = new List<string>();
        if (printS)
        {
            messages = succMessages;
        }
        else
        {
            messages = failMessages;
        }

        for (int i = 0; i < messages.Count; i++)
        {
            Console.WriteLine(messages[i]);
        }
    }

    public void PrintBag()
    {
        Console.Write(Name + " - ");
        if (bag.Count == 0)
        {
            Console.WriteLine("Nothing bought");
        }
        else
        {
            for (int i = 0; i < bag.Count; i++)
            {
                Console.Write(bag[i].Name);
                if (i < bag.Count - 1)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Введiть покупцiв: ");
            string pInput = Console.ReadLine();
            string[] pParts = pInput.Split(';');
            List<Person> people = new List<Person>();

            for (int i = 0; i < pParts.Length; i++)
            {
                string[] temp = pParts[i].Split('=');
                string name = temp[0];
                decimal money = decimal.Parse(temp[1]);
                people.Add(new Person(name, money));
            }

            Console.WriteLine("Введiть продукти: ");
            string prInput = Console.ReadLine();
            string[] prParts = prInput.Split(';');
            List<Product> product = new List<Product>();

            for (int i = 0; i < prParts.Length; i++)
            {
                string[] temp = prParts[i].Split('=');
                string name = temp[0];
                decimal cost = decimal.Parse(temp[1]);
                product.Add(new Product(name, cost));
            }

            string command = Console.ReadLine();
            while (!string.IsNullOrEmpty(command) && command != "END")
            {
                string[] parts = command.Split();
                string personName = parts[0];
                string productName = parts[1];

                Person buyer = null;
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Name == personName)
                    {
                        buyer = people[i];
                        break;
                    }
                }

                Product productBuy = null;
                for (int i = 0; i < product.Count; i++)
                {
                    if (product[i].Name == productName)
                    {
                        productBuy = product[i];
                        break;
                    }
                }

                if (buyer != null && productBuy != null)
                {
                    buyer.ByuProduct(productBuy);
                }
                command = Console.ReadLine();
            }

            for (int i = 0; i < people.Count; i++)
            {
                people[i].PrintMessages(true);
            }


            for (int i = 0; i < people.Count; i++)
            {
                people[i].PrintMessages(false);
            }

            for (int i = 0; i < people.Count; i++)
            {
                people[i].PrintBag();
            }
        }
        catch (Exception er)
        {
            Console.WriteLine(er.Message);
        }
    }
}