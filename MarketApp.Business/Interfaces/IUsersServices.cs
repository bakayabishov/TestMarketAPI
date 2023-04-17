using MarketApp.Business.Models;

namespace MarketApp.Business.Interfaces;

public interface IUsersServices
{
    Task<int> AddUsersAsync(UserDto user);
    Task<UserDetailsDto> GetUserDetails(int id) ;
    Task<List<UserDetailsDto>> GetAllAsync();
}