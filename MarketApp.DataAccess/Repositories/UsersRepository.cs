using MarketApp.DataAccess.Repositories.Interfaces;
using TestAPIMarket.Data.Entities;

namespace MarketApp.DataAccess.Repositories;

public class UsersRepository : BaseRepository<User>, IUsersRepository
{
    public UsersRepository(DataContext context) : base(context) { }


}