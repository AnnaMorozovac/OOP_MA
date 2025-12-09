namespace BookShop.StartUp
{
    using Microsoft.EntityFrameworkCore;
    using BookShop.Data;
    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BookShopContext())
            {
                //BookShopExtensions.Seed(context);

                while (true)
                {
                    Console.WriteLine(" -- BookShop --");
                    Console.WriteLine("2. Age Restriction");
                    Console.WriteLine("3. Golden Books");
                    Console.WriteLine("4. Books by Price");
                    Console.WriteLine("5. Not Released In");
                    Console.WriteLine("6. Book Titles by Category");
                    Console.WriteLine("7. Released Before Date");
                    Console.WriteLine("8. Author Search");
                    Console.WriteLine("9. Book Search");
                    Console.WriteLine("10. Book Search by Author");
                    Console.WriteLine("11. Count Books");
                    Console.WriteLine("12. Total Book Copies");
                    Console.WriteLine("13. Profit by Category");
                    Console.WriteLine("14. Most Recent Books");
                    Console.WriteLine("15. Increase Prices");
                    Console.WriteLine("16. Remove Books");
                    Console.WriteLine("0. Exit");
                    Console.Write("Select choose: ");

                    var command = Console.ReadLine();

                    switch (command)
                    {
                        case "2":
                            Console.WriteLine("Enter age restriction (minor/teen/adult): ");
                            string ageCommand = Console.ReadLine();
                            string result = BookShopManager.GetBookByAgeRestriction(context, ageCommand);
                            Console.WriteLine(result);
                            Console.WriteLine();
                            break;
                        case "3":
                            Console.WriteLine(BookShopManager.GetGoldenBooks(context));
                            Console.WriteLine();
                            break;
                        case "4":
                            Console.WriteLine(BookShopManager.GetBooksByPrice(context));
                            Console.WriteLine();
                            break;
                        case "5":
                            Console.Write("Enter year: ");
                            int year = int.Parse(Console.ReadLine());

                            Console.WriteLine(BookShopManager.GetBooksNotReleasedIn(context, year));
                            Console.WriteLine();
                            break;
                        case "6":
                            Console.Write("Input categories: ");
                            string input = Console.ReadLine();

                            Console.WriteLine(BookShopManager.GetBooksByCategory(context, input));
                            Console.WriteLine();
                            break;
                        case "7":
                            Console.WriteLine("Enter dare (dd-MM-yyyy): ");
                            string inputDate = Console.ReadLine();

                            Console.WriteLine(BookShopManager.GetBooksReleasedBefore(context, inputDate));
                            Console.WriteLine();
                            break;
                        case "8":
                            Console.Write("Enter ending string: ");
                            string inputEnding = Console.ReadLine();

                            Console.WriteLine(BookShopManager.GetAuthorNamesEndingIn(context, inputEnding));
                            Console.WriteLine();
                            break;
                        case "9":
                            Console.Write("Enter search string: ");
                            string inputSearch = Console.ReadLine();

                            Console.WriteLine(BookShopManager.GetBookTitlesContaining(context, inputSearch));
                            Console.WriteLine();
                            break;
                        case "10":
                            Console.Write("Enter author last name prefix: ");
                            string inputAuthor = Console.ReadLine();

                            Console.WriteLine(BookShopManager.GetBooksByAuthor(context, inputAuthor));
                            Console.WriteLine();
                            break;
                        case "11":
                            Console.Write("Enter length check: ");
                            int lengthCheck = int.Parse(Console.ReadLine());

                            Console.WriteLine(BookShopManager.CountBooks(context, lengthCheck));
                            Console.WriteLine();
                            break;
                        case "12":
                            Console.WriteLine(BookShopManager.CountCopiesByAuthor(context));
                            Console.WriteLine();
                            break;
                        case "13":
                            Console.WriteLine(BookShopManager.GetTotalProfitByCategory(context));
                            Console.WriteLine();
                            break;
                        case "14":
                            Console.WriteLine(BookShopManager.GetMostRecentBooks(context));
                            Console.WriteLine();
                            break;
                        case "15":
                            BookShopManager.IncreasePrices(context);
                            Console.WriteLine("Price updated successfully!");
                            Console.WriteLine();
                            break;
                        case "16":
                            Console.WriteLine($"{BookShopManager.RemoveBooks(context)} books were deleted");
                            Console.WriteLine();
                            break;
                        case "0":
                            Console.WriteLine("Exiting..");
                            return;

                        default:
                            Console.WriteLine("Unknown option, try again!");
                            break;
                    }
                }
            }
        }

    }
}
