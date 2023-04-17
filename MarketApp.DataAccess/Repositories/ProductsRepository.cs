using MarketApp.DataAccess.Entities;
using MarketApp.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketApp.DataAccess.Repositories;

public class ProductsRepository :  BaseRepository<Product, int>, IProductsRepository
{
    public ProductsRepository(DataContext context) : base(context) { }
    
    public override async Task<IEnumerable<Product>> GetAllAsync() {
        var result = await All.OrderBy(x => x.Name).Include(x => x.Shop).ToListAsync();
        return result;
    }
}