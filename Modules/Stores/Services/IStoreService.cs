using ShopeeAPI.Modules.Stores.DTO;

namespace ShopeeAPI.Modules.Stores.Services;

public interface IStoreService
{
    Task<IEnumerable<StoreDTO>> GetAllStores();
    Task<StoreDTO> AddStore(StoreCreateDTO store);
    Task<StoreDTO?> GetStoreById(int storeId);
    Task<StoreDTO?> UpdateStore(int storeId, StoreUpdateDTO data);
    Task<StoreDTO> DeleteStore(int storeId);
}

