namespace PO1_BillsPaymentSystem.Data.Models
{
    using System;
    public class CreditCard
    {
        public int CreditCardId { get; set; }

        public decimal Limit { get; private set; }
        public decimal MoneyOwed { get; set; }

        public decimal LimitLeft => Limit - MoneyOwed;

        public DateTime ExpirationDate { get; set; }

        public ICollection<PaymentMethod> PaymentMethods { get; set; } = new HashSet<PaymentMethod>();

        public CreditCard(decimal limit, decimal moneyOwed, DateTime expirationDate)
        {
            Limit = limit;
            MoneyOwed = moneyOwed;
            ExpirationDate = expirationDate;
        }

        public void Deposit(decimal amount)
        {
            if (amount > MoneyOwed)
                amount = MoneyOwed;

            MoneyOwed -= amount;
        }

        public void Withdraw(decimal amount)
        {
            if (LimitLeft >= amount)
                MoneyOwed += amount;
            else
                throw new InvalidOperationException("Недостатньо кредитного лiмiту!");
        }
    }
}
