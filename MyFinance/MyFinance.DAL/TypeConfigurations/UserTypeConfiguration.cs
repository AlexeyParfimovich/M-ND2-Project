using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinance.DAL.Entities;

namespace MyFinance.DAL.TypeConfigurations
{
    internal class UserTypeConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        private readonly string _tableName = "Users";

        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable(_tableName).HasKey(p => p.Id);

            builder.Property(p => p.FirstName).HasMaxLength(32).IsRequired();

            builder.Property(p => p.LastName).HasMaxLength(32);

            builder.Property(p => p.Email).HasMaxLength(64).IsRequired();

            builder.Property(p => p.Phone).HasMaxLength(32);

            builder.Property(p => p.Login).HasMaxLength(32).IsRequired();

            builder.Property(p => p.Password).HasMaxLength(32).IsRequired();

            builder.Property(p => p.IsActive).HasDefaultValue(false).IsRequired();

        }
    }
}
