using Microsoft.EntityFrameworkCore;
using TestAPIMarket.Data.Entities;

namespace TestAPIMarket.Data.Seeds;

public class ShopSeeds : ISeeds {
    public ModelBuilder Seed(ModelBuilder builder) {
        builder.Entity<Shop>()
            .HasData(new Shop {
                    Id = 1,
                    Name = "На диване"
                },
                new Shop {
                    Id = 1,
                    Name = "Строительный"
                });
        
        return builder;
    }
}