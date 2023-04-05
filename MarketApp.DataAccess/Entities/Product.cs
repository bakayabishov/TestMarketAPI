using MarketApp.DataAccess.Entities.Configurations;

namespace MarketApp.DataAccess.Entities;
/// <summary>
///     Configuration file for this entity <see cref="ProductConfiguration" />
/// </summary>
public class Product
{
    public int Id { get; set; }
    public Shop Shop { get; set; }
    public int ShopId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}