using System.Threading.Tasks;
using AutoMapper;
using MarketApp.API.Controllers.Responses;
using MarketApp.Business.Interfaces;
using MarketApp.Business.Models;
using MarketApp.Business.UnitOfWork;
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
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;


    public UserControllers(IUsersServices usersServices, IUnitOfWork unitOfWork, IMapper mapper) {
        _usersServices = usersServices;
        _uow = unitOfWork;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("AddUser")]
    [Authorize(Roles = $"{Role.Administrator}")]
    [ProducesResponseType(typeof(ApiResponse), 200)]
    public async Task<IActionResult> CreateAsync(UserDto user) {

        await _usersServices.AddUsersAsync(user);
        return Ok(ApiResponse.Success("Пользователь успешно создан"));
    }
}