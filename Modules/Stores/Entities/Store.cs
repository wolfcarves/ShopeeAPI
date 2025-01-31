using ShopeeAPI.Modules.Owners.Entities;

namespace ShopeeAPI.Modules.Stores.Entities;

public class Store
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int OwnerId { get; set; }
    public Owner Owner { get; set; } = null!;
}