namespace PO1_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PO1_BillsPaymentSystem.Data.Models;
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.Property(b => b.BankName)
                .HasMaxLength(50).IsUnicode(true);

            builder.Property(b => b.SwiftCode)
                .HasMaxLength(20).IsUnicode(false);
        }
    }
}
