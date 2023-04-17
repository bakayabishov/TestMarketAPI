using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MarketApp.Business.Models;
using MarketApp.Business.UnitOfWork;
using MarketApp.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MarketApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase{
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _uow;

    public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration) {
        _uow = unitOfWork;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginDto request) {
        var user = await _uow.Users.GetByLoginAsync(request.Name);


        if (user is null)
        {
            return BadRequest("User not found.");
        }
        
        string passwordHash
            = BCrypt.Net.BCrypt.HashPassword(request.Password);

        user.Name = request.Name;
        user.Password = passwordHash;
        
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            return BadRequest("Wrong password.");
        }

        string token = CreateToken(user);

        return Ok(token);
    }
    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim> {
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Role, "Administrator"),
            new(ClaimTypes.Role, "Manager"),
            new(ClaimTypes.Role, "Seller")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}