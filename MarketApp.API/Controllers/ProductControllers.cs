using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using MarketApp.API.Controllers.Responses;
using MarketApp.Business.Interfaces;
using MarketApp.Business.Models;
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
    public async Task<IActionResult> GetAllProductsAsync() {
        var userName = User.Identity.Name;
        return Ok(await _productsService.GetAllProductsAsync(userName));
    }
    
    [HttpPost]
    [Route("AddProducts")]
    [Authorized(Role.Manager)]
    [ProducesResponseType(typeof(ApiResponse), 200)]
    public async Task<IActionResult> CreateAsync(ProductDto product) {

        var userName = User.Identity.Name;
        await _productsService.AddAsync(product, userName);
        return Ok(ApiResponse.Success("Товар добавлен на склад"));
    }

    [HttpDelete]
    [Route("DeleteProduct")]
    [ProducesResponseType(typeof(ApiResponse), 200)]
    public async Task<IActionResult> Delete(int productId) {
        var userName = User.Identity.Name;
        await _productsService.RemoveItemsByIdAsync(productId, userName);
        return Ok(ApiResponse.Success("Товар удален со склада."));
    }
    
    [HttpPut]
    [Route("IncreaseProductAmount")]
    [Authorized(Role.Manager)]
    [ProducesResponseType(typeof(ApiValueResponse<int>), 200)]
    public async Task<IActionResult> IncreaseAmount(int id, int amount) {
        var newAmount = await _productsService.IncreaseProductAmountByIdAsync(id, amount);
   
        return Ok(ApiValueResponse<int>.Success("Количество товаров успешно обновлено.", newAmount));
    }
    
    [HttpPut]
    [Route("DecreaseProductAmount")]
    [Authorized(Role.Manager)]
    [ProducesResponseType(typeof(ApiValueResponse<int>), 200)]
    public async Task<IActionResult> DecreaseAmount(int id, int amount) {
        var newAmount = await _productsService.DecreaseProductAmountByIdAsync(id, amount);
   
        return Ok(ApiValueResponse<int>.Success("Количество товаров успешно обновлено.", newAmount));
    }
}