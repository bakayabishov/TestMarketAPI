using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestAPIMarket.Data.Entities.Configurations {
    /// <summary>
    /// Setting schema for Users table
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) {
            builder.ToTable("users");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Shop)
                .WithMany(x => x.Managers)
                .HasForeignKey(x => x.ShopId);
            
            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("password")
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
