using MarketApp.Business.Models;

namespace MarketApp.Business.Interfaces;

public interface IProductsService
{
    Task<List<ProductDto>> GetAllProductsAsync();
}