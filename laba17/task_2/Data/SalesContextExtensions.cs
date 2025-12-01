namespace PO3_SalesDatabase.Data
{
    using PO3_SalesDatabase.Data.Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection.Metadata;

    public static class SalesContextExtensions
    {
        public static void Seed(this SalesContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any() || context.Customers.Any() || context.Stores.Any() || context.Sales.Any())
            {
                return;
            }

            var random = new Random();

            var stores = CreateStores();
            var customers = CreateCustomers();
            var products = CreateRandomProducts(random);

            context.Stores.AddRange(stores);
            context.Customers.AddRange(customers);
            context.Products.AddRange(products);
            context.SaveChanges();

            var sales = CreateRandomSales(random, customers, products, stores);
            context.Sales.AddRange(sales);
            context.SaveChanges();
        }

        private static List<Store> CreateStores()
        {
            return new List<Store>()
         {
            new Store {Name = "Відділ Чернівці"},
            new Store {Name = "Відділ Києв"},
            new Store {Name = "Відділ Львів"},
            new Store {Name = "Відділ Хмельницьк"}
         };
        }

        private static List<Customer> CreateCustomers()
        {
            return new List<Customer>()
            {
                new Customer {Name = "Марія Литвенко", Email = "maria@gmai.com", CreadtCardNumber = "324234233"},
                new Customer {Name = "Наталія Сидрренко", Email = "natalia@gmai.com", CreadtCardNumber = "1111111"},
                new Customer {Name = "Андрій Коваль", Email = "andri@gmai.com", CreadtCardNumber = "2222222222"},
                new Customer {Name = "Сергій Шевченко", Email = "sergi@gmai.com", CreadtCardNumber = "3333333333"},
            };
        }

        private static List<Product> CreateRandomProducts(Random random)
        {
            var productName = new[] { "Ковбаса", "Гречка", "Чай", "Кава", "Ваніль" };
            var products = new List<Product>();

            for (int i = 0; i < 15; i++)
            {
                products.Add(new Product
                {
                    Name = productName[random.Next(productName.Length)] + $" ({i + 1})",
                    Quantity = random.Next(1, 100) * random.NextDouble(),
                    Price = random.Next(10, 500) + (decimal)random.NextDouble() * 5m
                });
            }

            return products;
        }

        private static List<Sale> CreateRandomSales(Random random, List<Customer> customers, List<Product> products, List<Store> stores)
        {
            var sales = new List<Sale>();
            for (int i = 0; i < 30; i++)
            {
                sales.Add(new Sale
                {
                    Customer = customers[random.Next(customers.Count)],
                    Product = products[random.Next(products.Count)],
                    Store = stores[random.Next(stores.Count)],
                    Date = DateTime.Now.AddDays(-random.Next(1, 90))
                });
            }
            return sales;
        }
    }
}
