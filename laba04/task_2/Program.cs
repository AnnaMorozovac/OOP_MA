using System;
using System.Numerics;

enum Season
{
    Spring,
    Winter,
    Autumn,
    Summer
}

enum DiscountType
{
    None,
    VIP,
    SecondVisit
}

class PriceCalculator
{
    private decimal pricePerDay;
    private int numberOfDay;
    private Season season;
    private DiscountType discount;

    public PriceCalculator(decimal pricePerDay, int numberOfDay, Season season, DiscountType discount)
    {
        this.pricePerDay = pricePerDay;
        this.numberOfDay = numberOfDay;
        this.season = season;
        this.discount = discount;
    }

    private int GerSeasonMult(Season season)
    {
        switch (season)
        {
            case Season.Autumn: return 1;
            case Season.Spring: return 2;
            case Season.Winter: return 3;
            case Season.Summer: return 4;
            default: return 1;
        }
    }

    private decimal GetDiscount(DiscountType discount)
    {
        switch (discount)
        {
            case DiscountType.VIP: return 0.20m;
            case DiscountType.SecondVisit: return 0.10m;
            default: return 0.0m;
        }
    }

    public decimal CalculatePrice()
    {
        int seasonMult = GerSeasonMult(season);
        decimal total = pricePerDay * numberOfDay * seasonMult;

        decimal discountV = GetDiscount(discount);
        total -= total * discountV;

        return total;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введiть данi: ");
        string[] input = Console.ReadLine().Split(' ');
        decimal pricePerday = decimal.Parse(input[0]);
        int numberOfdays = int.Parse(input[1]);
        Season season = Enum.Parse<Season>(input[2]);

        DiscountType discount = DiscountType.None;
        if (input.Length == 4)
        {
            discount = Enum.Parse<DiscountType>(input[3]);
        }

        PriceCalculator calculator = new PriceCalculator(pricePerday, numberOfdays, season, discount);
        decimal total = calculator.CalculatePrice();

        Console.WriteLine($"Загальна сума: {total:F2}");
    }
}