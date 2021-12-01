﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyFinance.DAL;

namespace MyFinance.DAL.Migrations
{
    [DbContext(typeof(FinanceDbContext))]
    [Migration("20211201101320_Initial_migration")]
    partial class Initial_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("finance")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyFinance.DAL.Entities.AccountEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<long>("BudgetId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("CurrencyType")
                        .HasColumnType("nvarchar(4)");

                    b.Property<decimal?>("LastTransaction")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("CurrencyType");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("MyFinance.DAL.Entities.BudgetEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("CurrencyType")
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyType");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("MyFinance.DAL.Entities.CardEntity", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal?>("LastTransaction")
                        .HasColumnType("decimal(20,0)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime?>("ValidThru")
                        .HasColumnType("datetime2");

                    b.HasKey("Name", "AccountId");

                    b.HasIndex("AccountId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("MyFinance.DAL.Entities.CurrencyEntity", b =>
                {
                    b.Property<string>("Type")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("ExchangeRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(5,4)")
                        .HasDefaultValue(1m);

                    b.Property<bool>("IsBase")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Type");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Type = "BYN",
                            ExchangeRate = 0m,
                            IsBase = true,
                            Name = "Белорусский рубль"
                        });
                });

            modelBuilder.Entity("MyFinance.DAL.Entities.AccountEntity", b =>
                {
                    b.HasOne("MyFinance.DAL.Entities.BudgetEntity", "Budget")
                        .WithMany("Accounts")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MyFinance.DAL.Entities.CurrencyEntity", "Currency")
                        .WithMany("Accounts")
                        .HasForeignKey("CurrencyType")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Budget");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("MyFinance.DAL.Entities.BudgetEntity", b =>
                {
                    b.HasOne("MyFinance.DAL.Entities.CurrencyEntity", "Currency")
                        .WithMany("Budgets")
                        .HasForeignKey("CurrencyType")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("MyFinance.DAL.Entities.CardEntity", b =>
                {
                    b.HasOne("MyFinance.DAL.Entities.AccountEntity", "Account")
                        .WithMany("Cards")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("MyFinance.DAL.Entities.AccountEntity", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("MyFinance.DAL.Entities.BudgetEntity", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("MyFinance.DAL.Entities.CurrencyEntity", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Budgets");
                });
#pragma warning restore 612, 618
        }
    }
}
