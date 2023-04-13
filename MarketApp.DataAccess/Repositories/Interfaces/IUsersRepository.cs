using MarketApp.DataAccess.Entities;

namespace MarketApp.DataAccess.Repositories.Interfaces;

public interface IUsersRepository : IBaseRepository<User>
{
    Task<bool> IsAlreadyRegisteredAsync(string name);
    Task<User?> GetUser(int id);
    Task<IEnumerable<User>> GetAllAsync();
}