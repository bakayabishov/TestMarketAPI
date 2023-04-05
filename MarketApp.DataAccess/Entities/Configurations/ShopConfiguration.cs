using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAPIMarket.Data.Entities;

namespace MarketApp.DataAccess.Entities.Configurations {
    /// <summary>
    /// Setting schema for Shops table
    /// </summary>
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder) {
            builder.ToTable("shops");
            builder.HasKey(x => x.Id);

            builder.HasKey(x => x.Id);
           
            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();
            
            builder.Property(x => x.Managers)
                .HasColumnName("manager")
                .IsRequired();
        }
    }
}