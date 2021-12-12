﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinance.DAL.Entities;

namespace MyFinance.DAL.EntityTypeConfigs
{
    internal class CardTypeConfiguration : IEntityTypeConfiguration<CardEntity>
    {
        private readonly string _tableName = "Cards";
        public void Configure(EntityTypeBuilder<CardEntity> builder)
        {
            builder.ToTable(_tableName).HasKey(t => new { t.Id });

            builder.Property(t => t.Id)
                .HasMaxLength(256)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(t => t.AccountId)
                .IsRequired();

            builder.HasOne(t => t.Account)
                .WithMany(t => t.Cards)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
