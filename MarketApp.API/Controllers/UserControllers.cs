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

public class UserControllers : ControllerBase
{
    private readonly IUsersServices _usersServices;


    public UserControllers(IUsersServices usersServices) {
        _usersServices = usersServices;

    }

    [HttpPost]
    [Route("AddUser")]
    [Authorized(Role.Administrator)]
    [ProducesResponseType(typeof(ApiResponse), 200)]
    public async Task<IActionResult> CreateAsync(UserDto user) {

        await _usersServices.AddUsersAsync(user);
        return Ok(ApiResponse.Success("Пользователь успешно создан"));
    }
   
   [HttpGet]
   [Route("GetAll")]
   [Authorized(Role.Manager, Role.Seller)]
   public async Task<IActionResult> GetAllUsersAsync() {
        
       return Ok(await _usersServices.GetAllAsync());
   }

    [HttpGet]
    [Route("GetUser")] 
    [Authorized(Role.Manager, Role.Seller)]
    public async Task<IActionResult> GetUserAsync(int id) {
        
        return Ok(await _usersServices.GetUserDetails(id));
    }

    [HttpPost]
    [Route("AddSeller")]
    [Authorized(Role.Manager)]
    [ProducesResponseType(typeof(ApiResponse), 200)]
    public async Task<IActionResult> CreateSellerAsync(SellerDto seller) {
        var manager = User.Identity.Name;

        await _usersServices.AddSellerAsync(seller, manager);
        return Ok(ApiResponse.Success("Профиль продовца успешно создан"));
    }
    [HttpDelete]
    [Route("RemoveSellerProfile")]
    [Authorized(Role.Manager)]
    [ProducesResponseType(typeof(ApiResponse), 200)]
    public async Task<IActionResult> Delete(string sellerName) {
        var userName = User.Identity.Name;
        await _usersServices.RemoveSellersByIdAsync(sellerName, userName);
        return Ok(ApiResponse.Success("Профиль продовца успешно удален"));
    }
}