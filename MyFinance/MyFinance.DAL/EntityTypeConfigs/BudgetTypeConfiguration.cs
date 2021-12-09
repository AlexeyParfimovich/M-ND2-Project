using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinance.DAL.Entities;

namespace MyFinance.DAL.EntityTypeConfigs
{
    internal class BudgetTypeConfiguration : IEntityTypeConfiguration<BudgetEntity>
    {
        private readonly string _tableName = "Budgets";

        public void Configure(EntityTypeBuilder<BudgetEntity> builder)
        {
            builder.ToTable(_tableName).HasKey(t => t.Id);

            builder.Property(t => t.Name).HasMaxLength(256).IsRequired();
            builder.Property(t => t.Balance).HasColumnType("decimal(18,2)").HasDefaultValue(0).IsRequired();

            builder.HasOne(t => t.Currency)
                .WithMany(t => t.Budgets)
                .HasForeignKey(t => t.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
