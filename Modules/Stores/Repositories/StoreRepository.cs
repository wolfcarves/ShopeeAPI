using Microsoft.EntityFrameworkCore;
using ShopeeAPI.Modules.Stores.DTO;
using ShopeeAPI.Modules.Stores.Entities;

namespace ShopeeAPI.Modules.Stores.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly AppDbContext _ctx;

    public StoreRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<Store>> GetAllAsync()
    {
        return await _ctx.Stores.ToListAsync();
    }

    public async Task<Store> CreateAsync(Store store)
    {
        await _ctx.Stores.AddAsync(store);
        await _ctx.SaveChangesAsync();

        return store;
    }

    public async Task<StoreDTO?> GetOneByIdAsync(int storeId)
    {
        return await _ctx.Stores
            .Include(s => s.Owner)
            .Select(s => new StoreDTO
            {
                Id = s.Id,
                Name = s.Name,
            })
            .FirstOrDefaultAsync(result => result.Id == storeId);
    }

    public async Task<Store> DeleteAsync(int storeId)
    {
        var store = await _ctx.Stores.FindAsync(storeId);

        _ctx.Stores.Entry(store).State = EntityState.Deleted;

        await _ctx.SaveChangesAsync();

        return store;
    }


}