using AutoMapper;
using MarketApp.DataAccess.Entities;
using Microsoft.OpenApi.Extensions;

namespace MarketApp.Business.Models.Mappings;

public class UserMappingProfile : Profile {
    public UserMappingProfile()
    {
        CreateMap<UserDto, User>().ReverseMap()
            .ForMember(dest => dest.ShopId, opt => opt.MapFrom(source => source.Shop.Id));

        CreateMap<User, UserDetailsDto>()
            .ForMember(dest => dest.ShopName, opt => opt.MapFrom(source => source.Shop.Name))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(source => source.Name))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(source => source.Role.GetDisplayName())).ReverseMap();
        
        CreateMap<ProductDto, Product>().ReverseMap()
            .ForMember(dest => dest.ShopId, opt => opt.MapFrom(source => source.Shop.Id));
    }
}