using MarketApp.DataAccess.Entities.Configurations;

namespace MarketApp.DataAccess.Entities;
/// <summary>
///     Configuration file for this entity <see cref="ShopConfiguration" />
/// </summary>
public class Shop
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ManagerId { get; set; }
    public ICollection<User> Managers { get; set; }
    public ICollection<Product> Products { get; set; }
}