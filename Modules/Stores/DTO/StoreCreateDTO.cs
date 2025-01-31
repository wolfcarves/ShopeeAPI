namespace ShopeeAPI.Modules.Stores.DTO;

public class StoreCreateDTO
{
    public required string Name { get; set; }
    public int OwnerId { get; set; }
}