namespace ShopeeAPI.Modules.Owners.Entities;

public class Owner
{
    public int Id { get; set; }
    public required string Fullname { get; set; }
    public required string Username { get; set; }
}