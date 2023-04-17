using MarketApp.Business.Models;
using MarketApp.DataAccess.Entities;

namespace MarketApp.Business.Interfaces;

public interface IUsersServices
{
    Task<int> AddUsersAsync(UserDto user);
    Task<UserDetailsDto> GetUserDetails(int id) ;
    Task<List<UserDetailsDto>> GetAllAsync();
}