namespace PO1_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PO1_BillsPaymentSystem.Data.Models;

    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasIndex(pm => new
            {
                pm.UserId,
                pm.BankAccountId,
                pm.CreditCardId
            }).IsUnique();

            builder.HasOne(pm => pm.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(pm => pm.UserId);

            builder.HasOne(pm => pm.BankAccount)
                .WithMany(b => b.PaymentMethods)
                .HasForeignKey(pm => pm.BankAccountId);

            builder.HasOne(pm => pm.CreditCard)
                .WithMany(c => c.PaymentMethods)
                .HasForeignKey(pm => pm.CreditCardId);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_PaymentMethod_OneAccount",
                    @"( (BankAccountId IS NULL AND CreditCardId IS NOT NULL) 
                    OR (BankAccountId IS NOT NULL AND CreditCardId IS NULL) )"
                );
            });
        }
    }
}
