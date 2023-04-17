using MarketApp.DataAccess.Entities;

namespace MarketApp.Business.Models;

public class UserDto
{
    public string Name { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    public int ShopId { get; set; }
}