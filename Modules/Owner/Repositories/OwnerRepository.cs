using Microsoft.EntityFrameworkCore;
using ShopeeAPI.Modules.Owner.Entities;

public class OwnerRepository : IOwnerRepository
{
    private readonly AppDbContext _context;

    public OwnerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Owner>> GetAllAsync()
    {
        return await _context.Owners.ToListAsync();
    }

    public async Task<Owner> GetOneAsync(int ownerId)
    {
        var owner = await _context.Owners.FindAsync(ownerId);

        if (owner == null) throw new KeyNotFoundException($"Owner with the id {ownerId} has not been found.s");

        return owner;
    }

    public async Task<Owner> CreateAsync()
    {

    }
}