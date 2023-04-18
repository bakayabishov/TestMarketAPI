using MarketApp.DataAccess.Entities;

namespace MarketApp.DataAccess.Repositories.Interfaces;

public interface IProductsRepository: IBaseRepository<Product, int>
{
    Task<IEnumerable<Product>> GetAllAsync(int shopId);
    Task<bool> IsAlreadyExistAsync(string name);
    Task DeleteItemsAsync(int productId, int shopId);
    Task<Product> GetByIdAsync(int id);
    Task<int> GetQuantityByIdAsync(int id);

}