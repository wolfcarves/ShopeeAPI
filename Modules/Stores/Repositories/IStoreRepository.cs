using ShopeeAPI.Modules.Stores.DTO;
using ShopeeAPI.Modules.Stores.Entities;

namespace ShopeeAPI.Modules.Stores.Repositories;

public interface IStoreRepository
{
    Task<IEnumerable<Store>> GetAllAsync();
    Task<Store> CreateAsync(Store store);
    Task<StoreDTO?> GetOneByIdAsync(int storeId);
    Task<StoreDTO> UpdateAsync(int storeId, StoreUpdateDTO data);

    Task<Store> DeleteAsync(int storeId);
}