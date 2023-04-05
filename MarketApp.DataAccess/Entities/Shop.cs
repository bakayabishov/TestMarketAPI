using TestAPIMarket.Data.Entities.Configurations;

namespace TestAPIMarket.Data.Entities;
/// <summary>
///     Configuration file for this entity <see cref="ShopConfiguration" />
/// </summary>
public class Shop
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<User> Managers { get; set; }
    public ICollection<Product> Products { get; set; }
}