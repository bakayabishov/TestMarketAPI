using MarketApp.DataAccess.Entities;
using MarketApp.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketApp.DataAccess.Repositories;

public class UsersRepository : BaseRepository<User, int>, IUsersRepository
{
    public UsersRepository(DataContext context) : base(context) { }
    
    public virtual async Task<bool> IsAlreadyRegisteredAsync(string name) {
        var query = All.Where(x => x.Name == name);
        return await query.AnyAsync();
    }
}