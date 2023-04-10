using AutoMapper;
using MarketApp.DataAccess.Entities;

namespace MarketApp.Business.Models.Mappings;

public class UserMappingProfile : Profile {
    public UserMappingProfile()
    {
        CreateMap<UserDto, User>();
        
        CreateMap<UserDetailsDto, User>()
            .ForMember(dest => dest.Shop.Name, opt => opt.MapFrom(source => source.ShopName))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.UserName))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(source => source.Role));
    }
}