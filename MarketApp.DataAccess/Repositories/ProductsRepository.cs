using MarketApp.DataAccess.Entities;
using MarketApp.DataAccess.Exceptions;
using MarketApp.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketApp.DataAccess.Repositories;

public class ProductsRepository :  BaseRepository<Product, int>, IProductsRepository
{
    public ProductsRepository(DataContext context) : base(context) { }
    
    public async Task<IEnumerable<Product>> GetAllAsync(int shopId) {
        var result = await All.Where(x => x.ShopId == shopId).OrderBy(x => x.Name).Include(x => x.Shop).ToListAsync();
        return result;
    }
    
    public async Task<Product> GetByIdAsync(int id) {
        var product =  await All.Include(x => x.Shop).Where(x => x.Id == id).FirstOrDefaultAsync();
        if (product == null)
        {
            throw new EntityNotFoundException("The item cannot be found.", id.ToString());
        }

        return product;        
    }

    public async Task<int> GetQuantityByIdAsync(int id) {
        var product =  await All.Include(x => x.Shop).Where(x => x.Id == id).FirstOrDefaultAsync();
        if (product == null)
        {
            throw new EntityNotFoundException("The item cannot be found.", id.ToString());
        }

        return product.Quantity;        
    }

    public async Task<bool> IsAlreadyExistAsync(string name) {
        var query = All.Where(x => x.Name == name);
        return await query.AnyAsync();
    }
    
    public async Task DeleteItemsAsync(int productId, int shopId) {
        var entities = await All.Where(item => item.ShopId == shopId && item.Id == productId).ToListAsync();
        if (!entities.Any()) {
            throw new Exception("There are no items in the warehouse.");
        }

        Context.Set<Product>().RemoveRange(entities);
    }
}