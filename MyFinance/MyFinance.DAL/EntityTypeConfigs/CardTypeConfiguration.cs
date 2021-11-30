using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinance.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.DAL.EntityTypeConfigs
{
    internal class CardTypeConfiguration : IEntityTypeConfiguration<CardEntity>
    {
        private readonly string _tableName = "Cards";
        public void Configure(EntityTypeBuilder<CardEntity> builder)
        {
            builder.ToTable(_tableName).HasKey(t => new { t.Name, t.AccountId });

            builder.Property(t => t.Name)
                .HasMaxLength(64)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(t => t.AccountId)
                .ValueGeneratedNever()
                .IsRequired();

            builder.HasOne(t => t.Account)
                .WithMany(t => t.Cards)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
