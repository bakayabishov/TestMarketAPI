using MarketApp.DataAccess.Entities;

namespace MarketApp.DataAccess.Repositories.Interfaces;

public interface IUsersRepository : IBaseRepository<User, int>
{
    Task<bool> IsAlreadyRegisteredAsync(string name);
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByLoginAsync(string login);
    Task DeleteSellersAsync(int sellerId, int shopId);
}