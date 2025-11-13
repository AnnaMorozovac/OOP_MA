using Microsoft.VisualBasic;
using System;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        Author = author;
        Title = title;
        Price = price;
    }

    public string Author
    {
        get { return author; }
        protected set
        {
            if (value.Split(' ').Length > 1)
            {
                string lastName = value.Split(' ')[1];
                if (char.IsDigit(lastName[0]))
                {
                    throw new ArgumentException("Author not valid");
                }
            }
            author = value;
        }
    }

    public string Title
    {
        get { return title; }
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid");
            }
            title = value;
        }
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid");
            }
            price = value;
        }
    }

    public override string ToString()
    {
        return $"Type: Book\n" +
               $"Title: {this.Title}\n" +
               $"Author: {this.Author}\n" +
               $"Price: {this.Price:F2}\n";
    }
}

public class GoldenEditionBook : Book
{
    public GoldenEditionBook(string author, string title, decimal price) 
        : base(author, title, price)
    {
    }

    public override decimal Price
    {
        get
        {
            return base.Price * 1.3m;
        }
    }

    public override string ToString()
    {
        return $"Type: GoldenEditionBook\n" +
               $"Title: {this.Title}\n" +
               $"Author: {this.Author}\n" +
               $"Price: {this.Price:F2}\n";
    }
}

public class Program
{
    static void Main()
    {
        try
        {
            string author = Console.ReadLine();
            string title = Console.ReadLine();
            decimal price = decimal.Parse(Console.ReadLine());

            Book books = new Book(author, title, price);
            GoldenEditionBook goldenEdition = new GoldenEditionBook(author, title, price);

            Console.WriteLine(books);
            Console.WriteLine(goldenEdition);
        }
        catch (ArgumentException er)
        {
            Console.WriteLine(er.Message);
        }
    }
}