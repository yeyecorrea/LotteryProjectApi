﻿// <auto-generated />
using System;
using LotteryProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LotteryProject.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240409231640_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LotteryProject.Entities.Models.Chance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LotteryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("LotteryId")
                        .IsUnique();

                    b.ToTable("chances");
                });

            modelBuilder.Entity("LotteryProject.Entities.Models.Lottery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("lotteries");
                });

            modelBuilder.Entity("LotteryProject.Entities.Models.Raffle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChanceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberRaffle")
                        .HasColumnType("int");

                    b.Property<decimal>("Prize")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Result")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChanceId");

                    b.ToTable("raffles");
                });

            modelBuilder.Entity("LotteryProject.Entities.Models.Chance", b =>
                {
                    b.HasOne("LotteryProject.Entities.Models.Lottery", "Lottery")
                        .WithOne("Chance")
                        .HasForeignKey("LotteryProject.Entities.Models.Chance", "LotteryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lottery");
                });

            modelBuilder.Entity("LotteryProject.Entities.Models.Raffle", b =>
                {
                    b.HasOne("LotteryProject.Entities.Models.Chance", "Chance")
                        .WithMany("Raffles")
                        .HasForeignKey("ChanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chance");
                });

            modelBuilder.Entity("LotteryProject.Entities.Models.Chance", b =>
                {
                    b.Navigation("Raffles");
                });

            modelBuilder.Entity("LotteryProject.Entities.Models.Lottery", b =>
                {
                    b.Navigation("Chance")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
