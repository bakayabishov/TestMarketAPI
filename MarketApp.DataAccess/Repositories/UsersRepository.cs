using MarketApp.DataAccess;
using MarketApp.DataAccess.Repositories.Interfaces;
using TestAPIMarket.Data.Entities;
using TestAPIMarket.Data.Repositories.Interfaces;

namespace TestAPIMarket.Data.Repositories;

public class UsersRepository : BaseRepository<User>, IUsersRepository
{
    public UsersRepository(DataContext context) : base(context) { }


}