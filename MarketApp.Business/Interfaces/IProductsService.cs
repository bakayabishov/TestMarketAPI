using MarketApp.Business.Models;

namespace MarketApp.Business.Interfaces;

public interface IProductsService
{
    Task<List<ProductDto>> GetAllProductsAsync(string name);
    Task<int> AddAsync(ProductDto product, string userName);
    Task RemoveItemsByIdAsync(int productId, string userName);
    Task<int> IncreaseProductAmountByIdAsync(int productId,  int quantity);
    Task<int> DecreaseProductAmountByIdAsync(int productId, int amount);
}