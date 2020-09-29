
using BlazorRemoteLinq.Shared.Entities;

using Microsoft.EntityFrameworkCore;

namespace BlazorRemoteLinq.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.ProductCategory)
                .WithMany()
                .HasForeignKey(x => x.ProductCategoryId);

            modelBuilder.Entity<Product>()
                .HasMany(x => x.Markets)
                .WithOne();

            modelBuilder.Entity<OrderItem>()
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<ProductMarket>()
                .HasKey(x => new { x.ProductId, x.MarketId });

            modelBuilder.Entity<ProductMarket>()
                .HasOne(x => x.Product)
                .WithMany(x => x.Markets)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<ProductMarket>()
                .HasOne(x => x.Market)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.MarketId);

            modelBuilder.Entity<Market>()
                .HasMany(x => x.Products)
                .WithOne(x => x.Market);


            modelBuilder.Entity<ProductCategory>()
                .HasData(
                    new ProductCategory
                    {
                        Id = 1,
                        Name = "Fruits"
                    },
                    new ProductCategory
                    {
                        Id = 2,
                        Name = "Vehicles"
                    }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = 1,
                        ProductCategoryId = 1,
                        Name = "Apple",
                        Price = 2
                    },
                    new Product
                    {
                        Id = 2,
                        ProductCategoryId = 1,
                        Name = "Pear",
                        Price = 1
                    },
                    new Product
                    {
                        Id = 3,
                        ProductCategoryId = 1,
                        Name = "Pineapple",
                        Price = 3
                    },
                    new Product
                    {
                        Id = 4,
                        ProductCategoryId = 2,
                        Name = "Car",
                        Price = 33999
                    },
                    new Product
                    {
                        Id = 5,
                        ProductCategoryId = 2,
                        Name = "Bicycle",
                        Price = 150
                    }
                );

            modelBuilder.Entity<OrderItem>()
                .HasData(
                    new OrderItem
                    {
                        Id = 1,
                        ProductId = 1,
                        Quantity = 2
                    },
                    new OrderItem
                    {
                        Id = 2,
                        ProductId = 2,
                        Quantity = 3
                    },
                    new OrderItem
                    {
                        Id = 3,
                        ProductId = 5,
                        Quantity = 3
                    }
                );

            modelBuilder.Entity<Market>()
                .HasData(
                    new Market
                    {
                        Id = 1,
                        Name = "Product destination market 1"
                    },
                    new Market
                    {
                        Id = 2,
                        Name = "Product destination market 2"
                    },
                    new Market
                    {
                        Id = 3,
                        Name = "Product destination market 3"
                    },
                    new Market
                    {
                        Id = 4,
                        Name = "Product destination market 4"
                    }
                );

            modelBuilder.Entity<ProductMarket>()
                .HasData(
                    new ProductMarket
                    {
                        Id = 1,
                        ProductId = 1,
                        MarketId = 1
                    },
                    new ProductMarket
                    {
                        Id = 2,
                        ProductId = 2,
                        MarketId = 1
                    },
                    new ProductMarket
                    {
                        Id = 3,
                        ProductId = 1,
                        MarketId = 3
                    },
                    new ProductMarket
                    {
                        Id = 4,
                        ProductId = 1,
                        MarketId = 4
                    }
                );

        }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Market> Markets { get; set; }

        public DbSet<ProductMarket> ProductMarkets { get; set; }
    }
}
