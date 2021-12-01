using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinance.DAL.Entities;

namespace MyFinance.DAL.EntityTypeConfigs
{
    internal class AccountTypeConfiguration : IEntityTypeConfiguration<AccountEntity>
    {
        private readonly string _tableName = "Accounts";

        public void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            builder.ToTable(_tableName).HasKey(t => t.Id);

            builder.Property(t => t.Name).HasMaxLength(256).IsRequired();
            builder.Property(t => t.Balance).HasColumnType("decimal(18,2)").HasDefaultValue(0).IsRequired();
            //builder.Property(t => t.LastTransaction);

            builder.HasOne(t => t.Currency)
                .WithMany(t => t.Accounts)
                .HasForeignKey(t => t.CurrencyType)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Budget)
                .WithMany(t => t.Accounts)
                .HasForeignKey(t => t.BudgetId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasIndex(t => t.Name).IsUnique();
        }
    }
}
