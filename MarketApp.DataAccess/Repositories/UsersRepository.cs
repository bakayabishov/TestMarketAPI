using MarketApp.DataAccess.Entities;
using MarketApp.DataAccess.Exceptions;
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
    
    public virtual async Task<User?> GetUser(string name) {
        var user =  await All.Include(x => x.Shop).Include(x => x.Role).Where(x => x.Name == name).FirstOrDefaultAsync();
            if (user == null)
        {
            throw new EntityNotFoundException("The user cannot be found.", name);
        }

        return user;        
    }
}