using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopeeAPI.Configuration;
using ShopeeAPI.Modules.Owners.DTO;
using ShopeeAPI.Modules.Owners.Entities;
using ShopeeAPI.Modules.Stores.DTO;

namespace ShopeeAPI.Modules.Owners.Repositories;

public class OwnerRepository : IOwnerRepository
{
    private readonly AppDbContext _ctx;
    private readonly IMapper _mapper;

    public OwnerRepository(AppDbContext ctx)
    {
        _ctx = ctx;
        _mapper = MapperConfig.InitializeAutomapper();
    }

    public async Task<IEnumerable<OwnerDTO>> GetAllAsync()
    {
        var owners = await _ctx.Owners
            .Include(o => o.Store)
            .Select(o => _mapper.Map<OwnerDTO>(o))
            .ToListAsync();

        return owners;
    }

    public async Task<Owner?> GetOneByIdAsync(int ownerId)
    {
        var owner = await _ctx.Owners
            .Include(o => o.Store)
            .FirstOrDefaultAsync(result => result.Id == ownerId);
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

    public async Task<Owner?> UpdateAsync(int id, Owner data)
    {
        var owner = await _ctx.Owners.FirstOrDefaultAsync(item => item.Id == id);

        if (owner != null)
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