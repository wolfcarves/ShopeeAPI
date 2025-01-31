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
        await _ctx.AddAsync(store);
        await _ctx.SaveChangesAsync();

        return store;
    }

    public async Task<Store> GetOneByIdAsync(int storeId)
    {
        var store = await _ctx.Stores.FindAsync(storeId);

        if (store == null) throw new KeyNotFoundException($"Store with the id {storeId} does not exists");

        return store;
    }


}