﻿// <auto-generated />
using System;
using AB_INVEST.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AB_INVEST.Migrations
{
    [DbContext(typeof(ABInvestContext))]
    partial class ABInvestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AB_INVEST.Models.AccountModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccountKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Balance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountKey")
                        .IsUnique()
                        .HasFilter("[AccountKey] IS NOT NULL");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("AB_INVEST.Models.DepositModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 20, 15, 54, 45, 315, DateTimeKind.Local).AddTicks(178));

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("AB_INVEST.Models.InvestmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("AnnualPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MinMonths")
                        .HasColumnType("int");

                    b.Property<decimal>("MinValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Investments");
                });

            modelBuilder.Entity("AB_INVEST.Models.TransferModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReceiverAccountId")
                        .HasColumnType("int");

                    b.Property<int>("SenderAccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverAccountId");

                    b.HasIndex("SenderAccountId");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("AB_INVEST.Models.UserInvestmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("AddedValue")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InitialValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("InvestmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("Id");

                    b.HasIndex("InvestmentId");

                    b.ToTable("UsersInvestments");
                });

            modelBuilder.Entity("AB_INVEST.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AB_INVEST.Models.WithdrawModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InitialValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("InvestmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("WithdrawDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("WithdrewValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("Id");

                    b.HasIndex("InvestmentId");

                    b.ToTable("Withdraws");
                });

            modelBuilder.Entity("AB_INVEST.Models.AccountModel", b =>
                {
                    b.HasOne("AB_INVEST.Models.UserModel", "User")
                        .WithOne("Account")
                        .HasForeignKey("AB_INVEST.Models.AccountModel", "UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AB_INVEST.Models.DepositModel", b =>
                {
                    b.HasOne("AB_INVEST.Models.AccountModel", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("AB_INVEST.Models.TransferModel", b =>
                {
                    b.HasOne("AB_INVEST.Models.AccountModel", "ReceiverAccount")
                        .WithMany()
                        .HasForeignKey("ReceiverAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AB_INVEST.Models.AccountModel", "SenderAccount")
                        .WithMany()
                        .HasForeignKey("SenderAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ReceiverAccount");

                    b.Navigation("SenderAccount");
                });

            modelBuilder.Entity("AB_INVEST.Models.UserInvestmentModel", b =>
                {
                    b.HasOne("AB_INVEST.Models.AccountModel", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AB_INVEST.Models.InvestmentModel", "Investment")
                        .WithMany()
                        .HasForeignKey("InvestmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Investment");
                });

            modelBuilder.Entity("AB_INVEST.Models.WithdrawModel", b =>
                {
                    b.HasOne("AB_INVEST.Models.AccountModel", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AB_INVEST.Models.InvestmentModel", "Investment")
                        .WithMany()
                        .HasForeignKey("InvestmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Investment");
                });

            modelBuilder.Entity("AB_INVEST.Models.UserModel", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
