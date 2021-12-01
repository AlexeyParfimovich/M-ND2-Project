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
                .HasKey(t => t.Type);

            builder
                .Property(t => t.Type)
                .HasMaxLength(4)
                .ValueGeneratedNever()
                .IsRequired();

            builder
                .Property(t => t.Name)
                .HasMaxLength(32)
                .IsRequired();

            builder
                .Property(t => t.IsBase)
                .HasDefaultValue(false)
                .IsRequired();

            builder
                .Property(t => t.ExchangeRate)
                .HasColumnType("decimal(5,4)")
                .HasDefaultValue(1)
                .IsRequired();

            builder.HasData( 
                new CurrencyEntity[]
                {
                    new CurrencyEntity { Type="BYN", Name="Белорусский рубль", IsBase=true}
                });
        }
    }
}
