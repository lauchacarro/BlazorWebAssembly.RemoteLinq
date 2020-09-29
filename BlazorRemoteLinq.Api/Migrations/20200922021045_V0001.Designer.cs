﻿// <auto-generated />
using BlazorRemoteLinq.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorRemoteLinq.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200922021045_V0001")]
    partial class V0001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlazorRemoteLinq.Shared.Entities.Market", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Markets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Product destination market 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Product destination market 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Product destination market 3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Product destination market 4"
                        });
                });

            modelBuilder.Entity("BlazorRemoteLinq.Shared.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Apple",
                            Price = 2m,
                            ProductCategoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pear",
                            Price = 1m,
                            ProductCategoryId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pineapple",
                            Price = 3m,
                            ProductCategoryId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Car",
                            Price = 33999m,
                            ProductCategoryId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Bicycle",
                            Price = 150m,
                            ProductCategoryId = 2
                        });
                });

            modelBuilder.Entity("BlazorRemoteLinq.Shared.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fruits"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Vehicles"
                        });
                });

            modelBuilder.Entity("BlazorRemoteLinq.Shared.Entities.ProductMarket", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("MarketId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "MarketId");

                    b.HasIndex("MarketId");

                    b.ToTable("ProductMarkets");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            MarketId = 1,
                            Id = 1
                        },
                        new
                        {
                            ProductId = 2,
                            MarketId = 1,
                            Id = 2
                        },
                        new
                        {
                            ProductId = 1,
                            MarketId = 3,
                            Id = 3
                        },
                        new
                        {
                            ProductId = 1,
                            MarketId = 4,
                            Id = 4
                        });
                });

            modelBuilder.Entity("Common.Model.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 2,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 5,
                            Quantity = 3
                        });
                });

            modelBuilder.Entity("BlazorRemoteLinq.Shared.Entities.Product", b =>
                {
                    b.HasOne("BlazorRemoteLinq.Shared.Entities.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlazorRemoteLinq.Shared.Entities.ProductMarket", b =>
                {
                    b.HasOne("BlazorRemoteLinq.Shared.Entities.Market", "Market")
                        .WithMany("Products")
                        .HasForeignKey("MarketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorRemoteLinq.Shared.Entities.Product", "Product")
                        .WithMany("Markets")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Common.Model.OrderItem", b =>
                {
                    b.HasOne("BlazorRemoteLinq.Shared.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
