using MarketApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketApp.DataAccess.Seeds;

public class UserSeeds : ISeeds {
    public ModelBuilder Seed(ModelBuilder builder) {
        builder.Entity<User>()
            .HasData(new User {
                    Id = 1,
                    Name = "Администратор",
                    Password = "Admin",
                    Role = Role.Administrator,
                    ShopId = 1
                },
                new User {
                    Id = 2,
                    Name = "Менеджер",
                    Password = "Manager",
                    Role = Role.Manager,
                    ShopId = 1
                },
                new User {
                    Id = 3,
                    Name = "Продавец",
                    Password = "Seller",
                    Role = Role.Seller,
                    ShopId = 1
                },
                new User {
                    Id = 4,
                    Name = "Администратор",
                    Password = "Admin",
                    Role = Role.Administrator,
                    ShopId = 2
                },
                new User {
                    Id = 5,
                    Name = "Менеджер",
                    Password = "Manager",
                    Role = Role.Manager,
                    ShopId = 2
                },
                new User {
                    Id = 6,
                    Name = "Продавец",
                    Password = "Seller",
                    Role = Role.Seller,
                    ShopId = 2
                });
        
        return builder;
    }
}