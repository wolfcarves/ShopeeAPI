using ShopeeAPI.Modules.Stores.Entities;

namespace ShopeeAPI.Modules.Stores.Repositories;

public interface IStoreRepository
{
    Task<IEnumerable<Store>> GetAllAsync();
    Task<Store> CreateAsync(Store store);
}