using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinance.DAL.Entities;

namespace MyFinance.DAL.EntityTypeConfigs
{
    internal class CurrencyTypeConfiguration : IEntityTypeConfiguration<CurrencyEntity>
    {
        private readonly string _tableName = "Currencies";

        public void Configure(EntityTypeBuilder<CurrencyEntity> builder)
        {
            builder
                .ToTable(_tableName)
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Id)
                .HasMaxLength(3)
                .ValueGeneratedNever()
                .IsRequired();

            builder
                .Property(t => t.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder
                .Property(t => t.ExchangeRate)
                .HasColumnType("decimal(5,4)")
                .HasDefaultValue(1)
                .IsRequired();

            builder.HasData( 
                new CurrencyEntity[]
                {
                    new CurrencyEntity { Id="BYN", Name="Белорусский рубль"},
                    new CurrencyEntity { Id="RUB", Name="Российский рубль"},
                    new CurrencyEntity { Id="USD", Name="Доллар США"},
                    new CurrencyEntity { Id="EUR", Name="Евро"},
                });
        }
    }
}
