using Microsoft.EntityFrameworkCore;
using ShopeeAPI.Modules.Owners.Entities;

namespace ShopeeAPI.Modules.Owners.Repositories;

public class OwnerRepository : IOwnerRepository
{
    private readonly AppDbContext _ctx;

    public OwnerRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<Owner>> GetAllAsync()
    {
        return await _ctx.Owners.ToListAsync();
    }

    public async Task<Owner> GetOneAsync(int ownerId)
    {
        var owner = await _ctx.Owners.FindAsync(ownerId);

        if (owner == null) throw new KeyNotFoundException($"Owner with the id {ownerId} has not been found.s");

        return owner;
    }

    public async Task<Owner> CreateAsync(Owner data)
    {
        await _ctx.Owners.AddAsync(data);
        await _ctx.SaveChangesAsync();

        return data;
    }

    public async Task<Owner> UpdateAsync(int ownerId, Owner data)
    {
        var owner = await _ctx.Owners.FindAsync();

        if (owner == null) throw new KeyNotFoundException($"Owner with the id {ownerId} does not exists");

        _ctx.Owners.Update(data);
        await _ctx.SaveChangesAsync();

        return data;
    }

    public async Task<Owner> DeleteAsync(int ownerId)
    {
        var owner = await _ctx.Owners.FirstOrDefaultAsync(result => result.Id == ownerId);

        if (owner == null) throw new KeyNotFoundException($"Owner with the id {ownerId} does not exists");

        _ctx.Owners.Entry(owner).State = EntityState.Deleted;

        await _ctx.SaveChangesAsync();

        return owner;
    }
}