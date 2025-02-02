namespace ShopeeAPI.Modules.Stores.DTO;

public class StoreCreateDTO
{
    public required string Name { get; set; }
    public required int OwnerId { get; set; }
}