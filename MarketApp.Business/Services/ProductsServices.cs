using AutoMapper;
using MarketApp.Business.Exceptions;
using MarketApp.Business.Interfaces;
using MarketApp.Business.Models;
using MarketApp.Business.UnitOfWork;
using MarketApp.DataAccess.Entities;
using MarketApp.DataAccess.Exceptions;

namespace MarketApp.Business.Services;

public class ProductsServices : IProductsService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uow;

    public ProductsServices(IMapper mapper, IUnitOfWork uow) {
        _mapper = mapper;
        _uow = uow;
    }

    public async Task<List<ProductDto>> GetAllProductsAsync(string name) {
        var user = await _uow.Users.GetByLoginAsync(name); 
        return _mapper.Map<List<ProductDto>>(await _uow.Products.GetAllAsync(user.ShopId));
    }
    
    public async Task<int> AddAsync(ProductDto product, string userName) {
        if (await _uow.Products.IsAlreadyExistAsync(product.Name))
        {
            throw new UserAlreadyExistException("Товар с таким наименованием уже есть в системе", product.Name);

        }
        var currentUser = await _uow.Users.GetByLoginAsync(userName);

        var entity = _mapper.Map<Product>(product);
        entity.ShopId = currentUser.ShopId;
        await _uow.Products.InsertAsync(entity);
        await _uow.SaveChangesAsync();
        return entity.Quantity;
    }
    public async Task RemoveItemsByIdAsync(int productId, string userName) {
        var product = await _uow.Products.GetByIdAsync(productId);
        
        if (product is null) {
            throw new EntityNotFoundException("Такого товара нет на складе");
        }

        var currentUser = await _uow.Users.GetByLoginAsync(userName);

        if (currentUser.ShopId != product.ShopId) {
            throw new Exception("Вы не можете удолять тавар другого магазина");
        }
  
        await _uow.Products.DeleteItemsAsync(productId, currentUser.ShopId);
        await _uow.SaveChangesAsync();
    }

    public async Task<int> IncreaseProductAmountByIdAsync(int productId, int amount) {
        var entityCurrent = await _uow.Products.GetByIdAsync(productId);

        var newQuantity = entityCurrent.Quantity + amount;
        entityCurrent.Quantity = newQuantity;

        _uow.Products.Update(entityCurrent);
        await _uow.SaveChangesAsync();
        return newQuantity;
    }

    public async Task<int> DecreaseProductAmountByIdAsync(int productId, int amount) {
        var entityCurrent = await _uow.Products.GetByIdAsync(productId);
        if (amount > entityCurrent.Quantity)
        {
            throw new Exception("Не достаточно товара на складе");
        }

        var newQuantity = entityCurrent.Quantity - amount;
        entityCurrent.Quantity = newQuantity;

        _uow.Products.Update(entityCurrent);
        await _uow.SaveChangesAsync();
        return newQuantity;
    }

    public async Task<int> SellProductsAsync(string productName, int amount, string userName) {
        var entity= await _uow.Products.GetByNameAsync(productName);
        var seller = await _uow.Users.GetByLoginAsync(userName);
        if (amount > entity.Quantity)
        {
            throw new Exception("Не достаточно товара на складе");
        }
        if (entity.ShopId != seller.ShopId)
        {
            throw new Exception("Вы можете продавать товар только из своего магазина");
        }

        var newQuantity = entity.Quantity - amount;
        entity.Quantity = newQuantity;

        _uow.Products.Update(entity);
        await _uow.SaveChangesAsync();
        return newQuantity;
    }
}