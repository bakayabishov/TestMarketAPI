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
   //[Authorized(Role.Manager, Role.Seller)]
   public async Task<IActionResult> Get() {
        
       return Ok(await _usersServices.GetAllAsync());
   }

    [HttpGet]
    [Route("GetUser")] 
    [Authorized(Role.Manager, Role.Seller)]
    public async Task<IActionResult> Get(int id) {
        
        return Ok(await _usersServices.GetUserDetails(id));
    }
}