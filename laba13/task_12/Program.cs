using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

class Order
{
    public string Company { get; set; }
    public int Amount { get; set; }
    public string Product { get; set; }

    public Order(string company, int amount, string product)
    {
        Company = company;
        Amount = amount;
        Product = product;
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var orders = new List<Order>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine().Trim('|', ' ');
            string[] parts = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            string company = parts[0];
            int amount = int.Parse(parts[1]);
            string product = parts[2];

            orders.Add(new Order(company, amount, product));
        }

        var result = orders.GroupBy(o => o.Company).OrderBy(g => g.Key).Select(g => new
                            {
                                Company = g.Key,
                                Product = g.GroupBy(o => o.Product).Select(gg => new
                                {
                                    Product = gg.Key,
                                    Total = gg.Sum(x => x.Amount)
                                }).ToList()
                            });

        foreach (var company in result)
        {
            string productOutputs = string.Join(", ", company.Product.Select(p => $"{p.Product}-{p.Total}"));
            Console.WriteLine($"{company.Company}: {productOutputs}");
        }
    }
}