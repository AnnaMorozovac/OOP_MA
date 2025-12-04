namespace P03_FootballBetting.Startup
{
    using P03_FootballBetting.Data;
    using P03_FootballBetting.Models;
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new FootballBettingContext())
            {
                context.Database.EnsureCreated();

                Console.WriteLine("Done!");
            }
        }

    }
}
