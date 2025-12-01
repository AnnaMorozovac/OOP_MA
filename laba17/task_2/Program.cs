using PO3_SalesDatabase.Data;
using System;
using System.Linq;

namespace PO3_SalesDatabase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new SalesContext())
            {
                Console.WriteLine(" -- Sales Datavase Setup -- ");

                //context.Database.EnsureCreated();

                context.Seed();

                Console.WriteLine("The SalesDB database is fully created and populated with available data!");

                var salesCount = context.Sales.Count();
                Console.WriteLine($"Added {salesCount} duy");
            }
        }
    }
}
