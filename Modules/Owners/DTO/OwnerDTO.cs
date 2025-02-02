using ShopeeAPI.Modules.Stores.DTO;

namespace ShopeeAPI.Modules.Owners.DTO;

public class OwnerDTO
{
    public int Id { get; set; }
    public required string Fullname { get; set; }
    public required string Username { get; set; }
}