﻿// <auto-generated />
using MarketApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarketApp.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230417090216_NameUniqueRefactoring")]
    partial class NameUniqueRefactoring
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MarketApp.DataAccess.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "кольцо",
                            Price = 45.4m,
                            Quantity = 4,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "ожерелье",
                            Price = 78.6m,
                            Quantity = 2,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "серьги",
                            Price = 4m,
                            Quantity = 2,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "браслет",
                            Price = 4m,
                            Quantity = 1,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "платье",
                            Price = 800.1m,
                            Quantity = 4,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 6,
                            Name = "туфли",
                            Price = 452.4m,
                            Quantity = 5,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 7,
                            Name = "шляпа",
                            Price = 12.3m,
                            Quantity = 7,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 8,
                            Name = "чулки",
                            Price = 12.4m,
                            Quantity = 45,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 9,
                            Name = "топор",
                            Price = 89.8m,
                            Quantity = 100,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 10,
                            Name = "молоток",
                            Price = 99.9m,
                            Quantity = 150,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 11,
                            Name = "гвозди",
                            Price = 1.5m,
                            Quantity = 10000,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 12,
                            Name = "изолента",
                            Price = 15.7m,
                            Quantity = 150,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 13,
                            Name = "лопата",
                            Price = 45.5m,
                            Quantity = 16,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 14,
                            Name = "грабли",
                            Price = 54.4m,
                            Quantity = 16,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 15,
                            Name = "вилы",
                            Price = 65.4m,
                            Quantity = 35,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 16,
                            Name = "газонакосилка",
                            Price = 455.5m,
                            Quantity = 5,
                            ShopId = 2
                        },
                        new
                        {
                            Id = 17,
                            Name = "серп",
                            Price = 55.9m,
                            Quantity = 10,
                            ShopId = 2
                        });
                });

            modelBuilder.Entity("MarketApp.DataAccess.Entities.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ManagerId")
                        .HasColumnType("int")
                        .HasColumnName("manager_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("shops", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ManagerId = 1,
                            Name = "На диване"
                        },
                        new
                        {
                            Id = 2,
                            ManagerId = 4,
                            Name = "Строительный"
                        });
                });

            modelBuilder.Entity("MarketApp.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar")
                        .HasColumnName("role");

                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Администратор",
                            Password = "Admin",
                            Role = "Administrator",
                            ShopId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Менеджер",
                            Password = "Manager",
                            Role = "Manager",
                            ShopId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Продавец",
                            Password = "Seller",
                            Role = "Seller",
                            ShopId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Администратор2",
                            Password = "Admin",
                            Role = "Administrator",
                            ShopId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Менеджер2",
                            Password = "Manager",
                            Role = "Manager",
                            ShopId = 2
                        },
                        new
                        {
                            Id = 6,
                            Name = "Продавец2",
                            Password = "Seller",
                            Role = "Seller",
                            ShopId = 2
                        });
                });

            modelBuilder.Entity("MarketApp.DataAccess.Entities.Product", b =>
                {
                    b.HasOne("MarketApp.DataAccess.Entities.Shop", "Shop")
                        .WithMany("Products")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("MarketApp.DataAccess.Entities.User", b =>
                {
                    b.HasOne("MarketApp.DataAccess.Entities.Shop", "Shop")
                        .WithMany("Managers")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("MarketApp.DataAccess.Entities.Shop", b =>
                {
                    b.Navigation("Managers");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
