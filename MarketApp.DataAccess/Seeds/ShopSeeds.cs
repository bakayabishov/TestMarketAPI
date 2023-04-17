using MarketApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketApp.DataAccess.Seeds;

public class ShopSeeds : ISeeds {
    public ModelBuilder Seed(ModelBuilder builder) {
        builder.Entity<Shop>()
            .HasData(new Shop {
                    Id = 1,
                    Name = "На диване",
                    ManagerId = 1
                },
                new Shop {
                    Id = 2,
                    Name = "Строительный",
                    ManagerId = 4
                });
        
        return builder;
    }
}