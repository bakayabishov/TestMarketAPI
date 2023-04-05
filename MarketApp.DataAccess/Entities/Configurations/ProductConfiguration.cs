using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestAPIMarket.Data.Entities.Configurations {
    /// <summary>
    /// Setting schema for Products table
    /// </summary>
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder) {
            builder.ToTable("products");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Shop)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ShopId);

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();
            
            builder.Property(x => x.Quantity)
                .HasColumnName("quantity")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnName("price")
                .HasColumnType("decimal")
                .IsRequired();
        }
    }
}