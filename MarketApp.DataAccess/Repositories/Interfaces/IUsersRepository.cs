using MarketApp.DataAccess.Entities;

namespace MarketApp.DataAccess.Repositories.Interfaces;

public interface IUsersRepository : IBaseRepository<User>
{
    Task<bool> IsAlreadyRegisteredAsync(string name);
    Task<User?> GetUser(string name);
}