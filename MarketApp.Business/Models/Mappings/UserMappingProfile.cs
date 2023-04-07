using AutoMapper;
using MarketApp.DataAccess.Entities;

namespace MarketApp.Business.Models.Mappings;

public class UserMappingProfile : Profile {
    public UserMappingProfile()
    {
        CreateMap<UserDto, User>();
    }
}