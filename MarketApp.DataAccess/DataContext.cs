using Microsoft.EntityFrameworkCore;
using TestAPIMarket.Data.Entities;

namespace MarketApp.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options, DbSet<User> users, DbSet<Shop> shops, DbSet<Product> products) : base(options)
        {
            Users = users;
            Shops = shops;
            Products = products;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=market;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
