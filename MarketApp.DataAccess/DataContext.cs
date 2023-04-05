using MarketApp.DataAccess.Entities;
using MarketApp.DataAccess.Entities.Configurations;
using MarketApp.DataAccess.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MarketApp.DataAccess
{
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options, DbSet<User> users, DbSet<Shop> shops, DbSet<Product> products) : base(options)
        {
            Users = users;
            Shops = shops;
            Products = products;
        }

        public class DbContextFactory : IDesignTimeDbContextFactory<DataContext>
        {
            public DataContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
                optionsBuilder.UseSqlServer("Server=localhost;user=sa;password=Moiparol7713!;Database=marketAPI;Trusted_Connection=true;TrustServerCertificate=true;");

                return new DataContext(optionsBuilder.Options, Users, Shops, Products);
            }
        }
        
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