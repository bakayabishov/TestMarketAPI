using MarketApp.DataAccess.Entities;
using MarketApp.DataAccess.Repositories.Interfaces;

namespace MarketApp.DataAccess.Repositories;

public class UsersRepository : BaseRepository<User>, IUsersRepository
{
    public UsersRepository(DataContext context) : base(context) { }


}