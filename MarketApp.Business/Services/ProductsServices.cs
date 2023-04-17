using AutoMapper;
using MarketApp.Business.Interfaces;
using MarketApp.Business.Models;
using MarketApp.Business.UnitOfWork;

namespace MarketApp.Business.Services;

public class ProductsServices : IProductsService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uow;

    public ProductsServices(IMapper mapper, IUnitOfWork uow) {
        _mapper = mapper;
        _uow = uow;
    }

    public async Task<List<ProductDto>> GetAllProductsAsync() {
        return _mapper.Map<List<ProductDto>>(await _uow.Products.GetAllAsync());
    }
}