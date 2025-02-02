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

    public async Task<Owner?> GetOneByIdAsync(int ownerId)
    {
        var owner = await _ctx.Owners.FirstOrDefaultAsync(result => result.Id == ownerId);
        return owner;
    }

    public async Task<Owner?> GetOneByUsernameAsync(string username)
    {
        var owner = await _ctx.Owners.FirstOrDefaultAsync(result => result.Username == username);
        return owner;
    }

    public async Task<Owner> CreateAsync(Owner data)
    {
        await _ctx.Owners.AddAsync(data);
        await _ctx.SaveChangesAsync();

        return data;
    }

    public async Task<Owner> UpdateAsync(int id, Owner data)
    {
        var owner = await _ctx.Owners.FirstOrDefaultAsync(item => item.Id == id);

        if (owner == null) throw new KeyNotFoundException($"Owner with the id {id} does not exists");

        owner.Fullname = data.Fullname;
        await _ctx.SaveChangesAsync();

        return owner;
    }

    public async Task<Owner> DeleteAsync(int id)
    {
        var owner = await _ctx.Owners.FirstOrDefaultAsync(result => result.Id == id);

        if (owner == null) throw new KeyNotFoundException($"Owner with the id {id} does not exists");

        _ctx.Owners.Entry(owner).State = EntityState.Deleted;

        await _ctx.SaveChangesAsync();

        return owner;
    }


}