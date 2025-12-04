namespace PO1_BillsPaymentSystem.Data
{
    using PO1_BillsPaymentSystem.Data.Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using Microsoft.EntityFrameworkCore;

    public class BillsPaymentSystemExtensions
    {
        public static void Seed(BillsPaymentSystemContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
                return;

            var random = new Random();

            var users = CreateUser();
            var bankAccounts = CreateBankAccounts(random);
            var credirCards = CreateCreditCards(random);
            var paymentMethods = CreatePaymentMethod(random, users, bankAccounts, credirCards);

            context.Users.AddRange(users);
            context.BankAccounts.AddRange(bankAccounts);
            context.CreditCards.AddRange(credirCards);
            context.PaymentMethods.AddRange(paymentMethods);

            context.SaveChanges();
        }

        public static void PayBills(BillsPaymentSystemContext context, int userId, decimal amount)
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

            decimal totalFunds = user.PaymentMethods.Where(pm => pm.BankAccount != null)
                .Sum(pm => pm.BankAccount.Balance) + user.PaymentMethods
                .Where(pm => pm.CreditCard != null)
                .Sum(pm => pm.CreditCard.LimitLeft);

            if (totalFunds < amount)
            {
                Console.WriteLine("Недостатньо коштiв!");
                return;
            }

            foreach (var ba in user.PaymentMethods.Where(pm => pm.BankAccount != null)
               .Select(pm => pm.BankAccount)
               .OrderBy(ba => ba.BankAccountId))
            {
                if (amount <= 0) break;

                decimal withdraw = Math.Min(ba.Balance, amount);
                ba.Withdraw(withdraw);
                amount -= withdraw;
            }

            foreach (var cc in user.PaymentMethods.Where(pm => pm.CreditCard != null)
                .Select(pm => pm.CreditCard).OrderBy(cc => cc.CreditCardId))
            {
                if (amount <= 0) break;

                decimal withdraw = Math.Min(cc.LimitLeft, amount);
                cc.Withdraw(withdraw);
                amount -= withdraw;
            }

            context.SaveChanges();
            Console.WriteLine("Рахунок успiшно оплачено!");
        }

        private static List<User> CreateUser()
        {
            return new List<User>
            {
                new User { FirstName = "Олександ", LastName = "Коваль", Email = "alex@mail.com", Password = "pass123" },
                new User { FirstName = "Марина", LastName = "Шевченко", Email = "marina@mail.com", Password = "marina456" },
                new User { FirstName = "Ігор", LastName = "Ткаченко", Email = "igor@mail.com", Password = "1234567" },
                new User { FirstName = "Ольга", LastName = "Гринюк", Email = "olga@mail.com", Password = "olga77" },
                new User { FirstName = "Дмитро", LastName = "Свачук", Email = "dima@mail.com", Password = "dimastr" },
            };
        }

        private static List<BankAccount> CreateBankAccounts(Random random)
        {
            string[] banks = { "ПриватБанк", "МоноБанк", "ОщадБанк" };

            var list = new List<BankAccount>();

            for (int i = 0; i < 6; i++)
            {
                list.Add(new BankAccount(
                    random.Next(500, 5000),
                    banks[random.Next(banks.Length)],
                    "SWFT" + random.Next(1000, 9999)
                ));

            }

            return list;
        }

        private static List<CreditCard> CreateCreditCards(Random random)
        {
            var list = new List<CreditCard>();

            for (int i = 0; i < 4; i++)
            {
                int limit = random.Next(1000, 5000);
                int owed = random.Next(0, limit);

                list.Add(new CreditCard(
                    limit,
                    owed,
                    DateTime.Now.AddYears(random.Next(1, 4))
                ));
            }

            return list;
        }

        private static List<PaymentMethod> CreatePaymentMethod(Random random, List<User> users, List<BankAccount> bankAccounts, List<CreditCard> creditCards)
        {
            var list = new List<PaymentMethod>();

            foreach (var user in users)
            {
                list.Add(new PaymentMethod
                {
                    User = user,
                    BankAccount = bankAccounts[random.Next(bankAccounts.Count)]
                });

                list.Add(new PaymentMethod
                {
                    User = user,
                    CreditCard = creditCards[random.Next(creditCards.Count)]
                });

                if (random.Next(0, 3) == 0)
                {
                    list.Add(new PaymentMethod
                    {
                        User = user,
                        BankAccount = bankAccounts[random.Next(bankAccounts.Count)]
                    });
                }
            }

            return list;
        }
    }
}
