namespace PO1_BillsPaymentSystem.App
{
    using Microsoft.EntityFrameworkCore;
    using PO1_BillsPaymentSystem.Data;
    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BillsPaymentSystemContext())
            {
                //context.Database.EnsureCreated();
                //BillsPaymentSystemExtensions.Seed(context);

                Console.Write("Введiть юзер айдi: ");
                int userId = int.Parse(Console.ReadLine());

                PrintUsersDetails(context, userId);

                Console.Write("Введiть суму для оплати: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                BillsPaymentSystemExtensions.PayBills(context, userId, amount);

                Console.WriteLine();
                Console.WriteLine("Пiсля оплати: ");
                PrintUsersDetails(context, userId);
            }
        }

        private static void PrintUsersDetails(BillsPaymentSystemContext context, int userId)
        {
            var user = context.Users.Include(u => u.PaymentMethods)
                .ThenInclude(pm => pm.BankAccount)
                .Include(u => u.PaymentMethods)
                .ThenInclude(pm => pm.CreditCard)
                .FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                Console.WriteLine($"Користувача з id {userId} не знайдено!");
                return;
            }

            Console.WriteLine($"Користувач: {user.FirstName} {user.LastName}");

            var bankAccounts = user.PaymentMethods.Where(pm => pm.BankAccount != null)
                .Select(pm => pm.BankAccount).ToList();

            var creditCards = user.PaymentMethods.Where(pm => pm.CreditCard != null)
                .Select(pm => pm.CreditCard).ToList();

            if (bankAccounts.Any())
            {
                Console.WriteLine("Банкiвськi рахунки: ");
                foreach (var ba in bankAccounts)
                {
                    Console.WriteLine($"-- ID: {ba.BankAccountId}");
                    Console.WriteLine($"--- Баланс: {ba.Balance:F2}");
                    Console.WriteLine($"--- Банк: {ba.BankName}");
                    Console.WriteLine($"--- SWIFT: {ba.SwiftCode}");
                }
            }

            if (creditCards.Any())
            {
                Console.WriteLine("Кредитнi карти: ");
                foreach (var cc in creditCards)
                {
                    Console.WriteLine($"-- ID: {cc.CreditCardId}");
                    Console.WriteLine($"--- Лiмiт: {cc.Limit:F2}");
                    Console.WriteLine($"--- Заборгованiсть: {cc.MoneyOwed:F2}");
                    Console.WriteLine($"--- Доступний лiмiт: {cc.LimitLeft:F2}");
                    Console.WriteLine($"--- Дата закiнчення: {cc.ExpirationDate:yyyy/MM}");
                }
            }
        }
    }
}
