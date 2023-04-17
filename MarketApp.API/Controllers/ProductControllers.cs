using System.Threading.Tasks;
using MarketApp.Business.Interfaces;
using MarketApp.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketApp.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]

public class ProductControllers : ControllerBase
{
    private readonly IProductsService _productsService;


    public ProductControllers(IProductsService productsService) {
        _productsService = productsService;
    }
       
    [HttpGet]
    [Route("GetAll")]
    [Authorized(Role.Manager, Role.Seller)]
    public async Task<IActionResult> Get() {
        
        return Ok(await _productsService.GetAllProductsAsync());
    }
}
    
