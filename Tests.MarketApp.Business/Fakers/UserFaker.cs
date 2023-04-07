using Bogus;
using MarketApp.DataAccess.Entities;

namespace MarketApp.Business.Tests.Fakers;

public class UserFaker
{
    public Faker<User> UserCreate()
    {
        return new Faker<User>()
            .UseSeed(9476)
            .RuleFor(x => x.Name, x => x.Random.Word())
            .RuleFor(x => x.Password, x => x.Random.String())
            .RuleFor(x => x.Role, x => x.PickRandom(Roles.Administrator, Roles.Manager, Roles.Seller));
    }
}