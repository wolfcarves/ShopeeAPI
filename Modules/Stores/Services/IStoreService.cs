using ShopeeAPI.Modules.Stores.DTO;
using ShopeeAPI.Modules.Stores.Entities;

namespace ShopeeAPI.Modules.Stores.Services;

public interface IStoreService
{
    Task<IEnumerable<Store>> GetAllStores();
    Task<Store> AddStore(StoreCreateDTO store);
    Task<StoreDTO?> GetStoreById(int storeId);
}

