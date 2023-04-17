using MarketApp.DataAccess.Entities;

namespace MarketApp.DataAccess.Repositories.Interfaces;

public interface IProductsRepository: IBaseRepository<Product>
{
    Task<IEnumerable<Product>> GetAllAsync();
}