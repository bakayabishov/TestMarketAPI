using MarketApp.DataAccess.Entities;
using MarketApp.DataAccess.Exceptions;
using MarketApp.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketApp.DataAccess.Repositories;

public sealed class UsersRepository : BaseRepository<User, int>, IUsersRepository
{
    public UsersRepository(DataContext context) : base(context) { }
    
    public async Task<bool> IsAlreadyRegisteredAsync(string name) {
        var query = All.Where(x => x.Name == name);
        return await query.AnyAsync();
    }
    
    public async Task<User?> GetByIdAsync(int id) {
        var user =  await All.Include(x => x.Shop).Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user == null)
        {
            throw new EntityNotFoundException("Пользователь не найден", id.ToString());
        }

        return user;        
    }
    
    public override async Task<IEnumerable<User>> GetAllAsync() {
        var result = await All.OrderBy(x => x.Name).Include(x => x.Shop).ToListAsync();
        return result;
    }
    
    public async Task<User?> GetByLoginAsync(string login) {
        return await All.Where(x => x.Name == login).FirstOrDefaultAsync();
    }
    
    public async Task DeleteSellersAsync(int sellerId, int shopId) {
        var entities = await All.Where(item => item.ShopId == shopId && item.Id == sellerId).ToListAsync();
        if (!entities.Any()) {
            throw new Exception("Пользователь не найден");
        }

        Context.Set<User>().RemoveRange(entities);
    }
}