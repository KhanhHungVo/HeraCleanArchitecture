﻿// <auto-generated />
using System;
using Hera.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hera.Infrastructure.Migrations
{
    [DbContext(typeof(HeraDbContext))]
    partial class HeraDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hera.Domain.Entities.CryptoCoin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long?>("CirculatingSupply")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CurrentDateTime")
                        .HasColumnType("datetime2");

                    b.Property<double?>("CurrentPrice")
                        .HasColumnType("float");

                    b.Property<long?>("MarketCap")
                        .HasColumnType("bigint");

                    b.Property<long?>("MarketCapRanking")
                        .HasColumnType("bigint");

                    b.Property<long?>("MaxSupply")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("PercentChange24H")
                        .HasColumnType("float");

                    b.Property<double?>("PercentChange7D")
                        .HasColumnType("float");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TotalSupply")
                        .HasColumnType("bigint");

                    b.Property<long?>("Volume24h")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("CryptoCoins");
                });

            modelBuilder.Entity("Hera.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "heraadmin@gmail.com",
                            Password = "$2a$12$5Eh7piUI9mmYADj7FE99deuQvFoSnPvW13n9GvgR/ijGoI5ZDAo9.",
                            Role = 0,
                            UserName = "heraadmin"
                        });
                });

            modelBuilder.Entity("Hera.Domain.Entities.UserFavorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CryptoCoinSymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserFavorites");
                });
#pragma warning restore 612, 618
        }
    }
}
