namespace ShopeeAPI.Modules.Owners.Entities;

public class Owner
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string Username { get; set; }
}