using MarketApp.API.Controllers.Responses;
using MarketApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketApp.API.Controllers;

[Microsoft.AspNetCore.Components.Route("[controller]")]
[ApiController]
[ProducesResponseType(typeof(ApiResponse), 500)]

public class UserControllers : ControllerBase
{
    private readonly IUsersServices _usersServices;

    public UserControllers(IUsersServices usersServices) {
        _usersServices = usersServices;
    }
}