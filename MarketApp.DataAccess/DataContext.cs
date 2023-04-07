using MarketApp.DataAccess.Entities;
using MarketApp.DataAccess.Entities.Configurations;
using MarketApp.DataAccess.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MarketApp.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ShopConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.Seed(new UserSeeds());
            modelBuilder.Seed(new ShopSeeds());
            modelBuilder.Seed(new ProductSeeds());
        }

        public static DbSet<User> Users { get; set; }
        public static DbSet<Shop> Shops { get; set; }
        public static DbSet<Product> Products { get; set; }

    }
}