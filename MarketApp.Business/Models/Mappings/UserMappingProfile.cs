using AutoMapper;
using TestAPIMarket.Data.Entities;

namespace MarketApp.Business.Models.Mappings;

public class UserMappingProfile : Profile {
    public UserMappingProfile()
    {
        CreateMap<UserDto, User>();
    }

}