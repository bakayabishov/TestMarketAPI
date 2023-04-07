using MarketApp.DataAccess.Entities;

namespace MarketApp.Business.Models;

public class UserDetailsDto
{
    public string UserName { get; set; }
    public string ShopName { get; set; }
    public Roles Role { get; set; }
}