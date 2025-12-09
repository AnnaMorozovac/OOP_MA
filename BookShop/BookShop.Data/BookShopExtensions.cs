namespace BookShop.Data
{
    using BookShop.Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    public class BookShopExtensions
    {
        public static void Seed(BookShopContext context)
        {
            context.Database.EnsureCreated();

            if(context.Authors.Any() || context.Books.Any() || context.Categories.Any())
                    return;

            var random = new Random();

            var authors = CreateAuthors();
            var categories = CreateCategories();
            var books = CreateBooks(random, authors);
            var bookCategories = CreateBookCategories(random, books, categories);

            context.Authors.AddRange(authors);
            context.Categories.AddRange(categories);
            context.Books.AddRange(books);
            context.BookCategories.AddRange(bookCategories);

            context.SaveChanges();
        }

        private static List<Author> CreateAuthors()
        {
            return new List<Author>
            {
                new Author { FirstName = "Serhiy", LastName = "Zhadan" },
                new Author { FirstName = "Oksana", LastName = "Zabuzhko" },
                new Author { FirstName = "Yuri", LastName = "Andrukhovych" },
                new Author { FirstName = "Andriy", LastName = "Kurkov" },
                new Author { FirstName = "Liubko", LastName = "Deresh" }
            };
        }

        private static List<Category> CreateCategories()
        {
            return new List<Category>
            {
                new Category { Name = "Fiction" },
                new Category { Name = "Classics" },
                new Category { Name = "Fantasy" },
                new Category { Name = "Romance" },
                new Category { Name = "Adventure" },
            };
        }

        private static List<Book> CreateBooks(Random random, List<Author> authors)
        {
            var titles = new[]
            {
                "Shadows of the Past",
                "Whispers of Freedom",
                "The Silent Step",
                "Echoes of Eternity",
                "Dreams of Tomorrow",
                "Voices in the Wind",
                "The Forgotten Path"
            };

            var descriptions = new[]
            {
                "Historical novel",
                "Romantic story",
                "Fantasy adventure",
                "Philosophical essay",
                "Mystery thriller",
                "Classic drama"
            };

            var list = new List<Book>();

            for (int i = 0; i < titles.Length; i++)
            {
                var book = new Book
                {
                    Title = titles[i],
                    Description = descriptions[random.Next(descriptions.Length)],
                    ReleaseDate = DateTime.Now.AddYears(-random.Next(1, 100)),
                    Copies = random.Next(50, 500),
                    Price = Math.Round((decimal)(random.NextDouble() * 30 + 5)),
                    EditionType = (EditionType)random.Next(0, 3),
                    AgeRestriction = (AgeRestriction)random.Next(0, 3),
                    Author = authors[random.Next(authors.Count)]
                };

                list.Add(book);
            }

            return list;
        }

        private static List<BookCategory> CreateBookCategories(Random random, List<Book> books, List<Category> categories)
        {
            var list = new List<BookCategory>();

            foreach (var book in books)
            {
                int numberOfCategories = random.Next(1, 4);

                for (int i = 0; i < numberOfCategories; i++)
                {
                    var category = categories[random.Next(categories.Count)];

                    if (!list.Any(bc => bc.Book == book && bc.Category == category))
                    {
                        list.Add(new BookCategory
                        {
                            Book = book,
                            Category = category
                        });
                    }
                }
            }

            return list;
        }

    }
}
