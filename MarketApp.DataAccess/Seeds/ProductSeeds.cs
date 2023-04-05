using Microsoft.EntityFrameworkCore;
using TestAPIMarket.Data.Entities;

namespace TestAPIMarket.Data.Seeds;

public class ProductSeeds : ISeeds {
    public ModelBuilder Seed(ModelBuilder builder) {
        builder.Entity<Product>()
            .HasData(new Product {
                    Id = 1,
                    Name = "кольцо",
                    Quantity = 4,
                    Price = new decimal(45.4),
                    ShopId = 1
                },
                new Product {
                    Id = 2,
                    Name = "ожерелье",
                    Quantity = 2,
                    Price = new decimal(78.6),
                    ShopId = 1
                },
                new Product {
                    Id = 3,
                    Name = "серьги",
                    Quantity = 2,
                    Price = new decimal(4),
                    ShopId = 1
                },
                new Product {
                    Id = 4,
                    Name = "браслет",
                    Quantity = 1,
                    Price = new decimal(4),
                    ShopId = 1
                },
                new Product {
                    Id = 5,
                    Name = "платье",
                    Quantity = 4,
                    Price = new decimal(800.1),
                    ShopId = 1
                },
                new Product {
                    Id = 6,
                    Name = "туфли",
                    Quantity = 5,
                    Price = new decimal(452.4),
                    ShopId = 1
                },
                new Product {
                    Id = 7,
                    Name = "шляпа",
                    Quantity = 7,
                    Price = new decimal(12.3),
                    ShopId = 1
                },
                new Product {
                    Id = 8,
                    Name = "чулки",
                    Quantity = 45,
                    Price = new decimal(12.4),
                    ShopId = 1
                },
                new Product {
                    Id = 1,
                    Name = "топор",
                    Quantity = 100,
                    Price = new decimal(89.8),
                    ShopId = 2
                },
                new Product {
                    Id = 2,
                    Name = "молоток",
                    Quantity = 150,
                    Price = new decimal(99.9),
                    ShopId = 2
                    
                },
                new Product {
                    Id = 3,
                    Name = "гвозди",
                    Quantity = 10000,
                    Price = new decimal(1.5),
                    ShopId = 2
                },
                new Product {
                    Id = 4,
                    Name = "изолента",
                    Quantity = 150,
                    Price = new decimal(15.7),
                    ShopId = 2
                },
                new Product {
                    Id = 5,
                    Name = "лопата",
                    Quantity = 16,
                    Price = new decimal(45.5),
                    ShopId = 2
                },
                new Product {
                    Id = 6,
                    Name = "грабли",
                    Quantity = 16,
                    Price = new decimal(54.4),
                    ShopId = 2
                },
                new Product {
                    Id = 7,
                    Name = "вилы",
                    Quantity = 35,
                    Price = new decimal(65.4),
                    ShopId = 2
                },
                new Product {
                    Id = 8,
                    Name = "газонакосилка",
                    Quantity = 5,
                    Price = new decimal(455.5),
                    ShopId = 2
                },
                new Product {
                    Id = 9,
                    Name = "серп",
                    Quantity = 10,
                    Price = new decimal(55.9),
                    ShopId = 2
                });
        
        return builder;
    }
}