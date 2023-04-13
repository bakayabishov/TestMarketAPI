using Bogus;
using MarketApp.Business.Models;
using MarketApp.DataAccess.Entities;

namespace MarketApp.Business.Tests.Fakers;

public class UserDtoFaker
{
    public Faker<UserDto> NewUser()
    {
        return new Faker<UserDto>()
            .UseSeed(9376)
            .RuleFor(x => x.Name, x => x.Random.Word())
            .RuleFor(x => x.Password, x => x.Random.String())
            .RuleFor(x => x.Role, x => x.PickRandom<Role>());
        
    }
}