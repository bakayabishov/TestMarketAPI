using AutoMapper;
using TestAPIMarket.Data.Entities;

namespace MarketApp.API.Models.Mappings;

public class UserMappingProfile : Profile {
    public UserMappingProfile()
    {
        CreateMap<UserDto, User>();
    }

}