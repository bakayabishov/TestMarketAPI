using MarketApp.Business.Models;

namespace MarketApp.Business.Interfaces;

public interface IUsersServices
{
    Task AddUsersAsync(UserDto user);
    Task<UserDetailsDto> GetUserDetails(string name) ;
}