namespace PO1_BillsPaymentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BankAccount
    {
        public int BankAccountId { get; set; }

        public decimal Balance { get; private set; }

        public string BankName { get; set; }
        public string SwiftCode { get; set; }

        public ICollection<PaymentMethod> PaymentMethods { get; set; } = new HashSet<PaymentMethod>();

        public BankAccount(decimal balance, string bankName, string swiftCode)
        {
            Balance = balance;
            BankName = bankName;
            SwiftCode = swiftCode;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (Balance >= amount)
                Balance -= amount;
            else
                throw new InvalidOperationException("Недостатньо коштiв на банкiвському рахунку!");
        }
    }
}
