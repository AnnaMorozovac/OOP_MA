using BookShop.Data;
using BookShop.Models;

namespace BookShop.StartUp
{
    public class BookShopManager
    {
        //2
        public static string GetBookByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction;
            try
            {
                ageRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);
                
            }
            catch
            {
                return $"Unknown age limit: {command}";
            }

            var titles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title).OrderBy(t => t).ToList();

            return string.Join(Environment.NewLine, titles);
        }


        //3
        public static string GetGoldenBooks(BookShopContext context)
        {
            var titles = context.Books.Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId).Select(b => b.Title).ToList();

            return string.Join(Environment.NewLine, titles);
        }


        //4
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price).Select(b => new { b.Title, b.Price })
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.Price:F2}"));
        }

        //5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var titles = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId).Select(b => b.Title).ToList();

            return string.Join(Environment.NewLine, titles);
        }

        //6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var catrgories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var titles = context.Books
                .Where(b => b.BookCategories.Any(bc => catrgories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title).OrderBy(t => t).ToList();

            return string.Join(Environment.NewLine, titles);
        }

        //7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value < parsedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                }).ToList();

            return string.Join(Environment.NewLine,
                books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}"));
        }

        //8
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            input = input.ToLower();

            var authors = context.Authors
                .Where(a => a.FirstName.ToLower().EndsWith(input)).OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName).Select(a => a.FirstName + " " + a.LastName).ToList();

            return string.Join(Environment.NewLine, authors);
        }

        //9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            input = input.ToLower();

            var titles = context.Books
                .Where(b => b.Title.ToLower().Contains(input)).Select(b => b.Title)
                .OrderBy(t => t).ToList();

            return string.Join(Environment.NewLine, titles);
        }

        //10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            input = input.ToLower();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input))
                .OrderBy(b => b.BookId).Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //11
        public static string CountBooks(BookShopContext context, int lengthCheck)
        {
            int count = context.Books
                .Where(b => b.Title.Length > lengthCheck).Count();

            return $"There are {count} books with longer title than {lengthCheck} symbols";
        }

        //12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                }).OrderByDescending(a => a.TotalCopies).ToList();

            return string.Join(Environment.NewLine, authors.Select(a => $"{a.FullName} - {a.TotalCopies}"));
        }

        //13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories.Select(c => new
            {
                CategoryName = c.Name,
                Profit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
            }).OrderByDescending(c => c.Profit).ThenBy(c => c.CategoryName).ToList();

            return string.Join(Environment.NewLine, categories.Select(c => $"{c.CategoryName} ${c.Profit:F2}"));
        }

        //14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories.Select(c => new
            {
                CaregoryName = c.Name,
                Books = c.CategoryBooks.OrderByDescending(cb => cb.Book.ReleaseDate)
                .Take(3).Select(cb => new
                {
                    cb.Book.Title,
                    Year = cb.Book.ReleaseDate.Value.Year
                }).ToList(),
                TotalBooks = c.CategoryBooks.Count
            }).OrderByDescending(c => c.TotalBooks).ToList();

            return string.Join(Environment.NewLine, categories.Select(c => $"--{c.CaregoryName}{Environment.NewLine}"
                    + string.Join(Environment.NewLine, c.Books.Select(b => $"{b.Title} ({b.Year})"))));
        }

        //15
        public static void IncreasePrices(BookShopContext context)
        {
            var booksToUpdate = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010).ToList();

            foreach (var book in booksToUpdate)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //16
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books.Where(b => b.Copies < 4200).ToList();

            int removedCount = booksToRemove.Count;

            context.Books.RemoveRange(booksToRemove);
            context.SaveChanges();

            return removedCount;
        }
    }
}
