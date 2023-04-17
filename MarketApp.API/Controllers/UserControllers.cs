using System.Threading.Tasks;
using AutoMapper;
using MarketApp.API.Controllers.Responses;
using MarketApp.Business.Interfaces;
using MarketApp.Business.Models;
using MarketApp.Business.UnitOfWork;
using MarketApp.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MarketApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserControllers : ControllerBase
{
    private readonly IUsersServices _usersServices;
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public UserControllers(IUsersServices usersServices, IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration) {
        _usersServices = usersServices;
        _uow = unitOfWork;
        _mapper = mapper;
        _configuration = configuration;
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