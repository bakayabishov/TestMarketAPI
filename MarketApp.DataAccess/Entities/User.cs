using MarketApp.DataAccess.Entities.Configurations;

namespace MarketApp.DataAccess.Entities;
/// <summary>
///     Configuration file for this entity <see cref="UserConfiguration" />
/// </summary>

public class User
{
    public int Id { get; set; }
    public Shop Shop { get; set; }
    public int ShopId { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    
}
