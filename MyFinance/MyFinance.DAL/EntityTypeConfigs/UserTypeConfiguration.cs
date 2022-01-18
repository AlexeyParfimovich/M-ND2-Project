using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinance.DAL.Entities;

namespace MyFinance.DAL.EntityTypeConfigs
{
    internal class UserTypeConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        private readonly string _tableName = "Users";

        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable(_tableName).HasKey(t => t.Id);

            builder.Property(t => t.UserName)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(t => t.FirstName)
                .HasMaxLength(256);

            builder.Property(t => t.LastName)
                .HasMaxLength(256);

            builder.Property(t => t.Email)
                .HasMaxLength(256)
                .IsRequired();

            builder.HasData(
                new UserEntity[]
                {
                    new UserEntity { Id=System.Guid.NewGuid(), UserName="TestUser", FirstName = "Test", LastName = "Testov", Email = "test@test.by"},
                });
        }
    }
}
