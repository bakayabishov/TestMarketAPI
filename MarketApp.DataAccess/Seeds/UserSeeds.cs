using Microsoft.EntityFrameworkCore;
using TestAPIMarket.Data.Entities;

namespace TestAPIMarket.Data.Seeds;

public class UserSeeds : ISeeds {
    public ModelBuilder Seed(ModelBuilder builder) {
        builder.Entity<User>()
            .HasData(new User {
                    Id = 1,
                    Name = "Администратор",
                    Password = "Admin",
                    Role = "administrator",
                    ShopId = 1
                },
                new User {
                    Id = 2,
                    Name = "Менеджер",
                    Password = "Manager",
                    Role = "manager",
                    ShopId = 1
                },
                new User {
                    Id = 3,
                    Name = "Продавец",
                    Password = "Seller",
                    Role = "seller",
                    ShopId = 1
                },
                new User {
                    Id = 4,
                    Name = "Администратор",
                    Password = "Admin",
                    Role = "administrator",
                    ShopId = 2
                },
                new User {
                    Id = 5,
                    Name = "Менеджер",
                    Password = "Manager",
                    Role = "manager",
                    ShopId = 2
                },
                new User {
                    Id = 6,
                    Name = "Продавец",
                    Password = "Seller",
                    Role = "seller",
                    ShopId = 2
                });
        
        return builder;
    }
}