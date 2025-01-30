using Microsoft.EntityFrameworkCore;
using ShopeeAPI.Modules.Owners.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Owner> Owners { get; set; }
}