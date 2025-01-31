using Microsoft.EntityFrameworkCore;
using ShopeeAPI.Modules.Owners.Entities;
using ShopeeAPI.Modules.Stores.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Owner> Owners { get; set; }
    public DbSet<Store> Stores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Owner>()
            .HasOne(o => o.Store)
            .WithOne(o => o.Owner)
            .HasForeignKey<Store>(s => s.OwnerId)
            .IsRequired();
    }
}