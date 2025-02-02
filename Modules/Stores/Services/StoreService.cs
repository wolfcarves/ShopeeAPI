using AutoMapper;
using ShopeeAPI.Configuration;
using ShopeeAPI.Modules.Owners.Repositories;
using ShopeeAPI.Modules.Stores.DTO;
using ShopeeAPI.Modules.Stores.Entities;
using ShopeeAPI.Modules.Stores.Repositories;

namespace ShopeeAPI.Modules.Stores.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;
    private readonly IOwnerRepository _ownerRepository;
    private readonly ILogger<StoreService> _logger;
    private readonly IMapper _mapper;

    public StoreService(IStoreRepository storeRepository, IOwnerRepository ownerRepository, ILogger<StoreService> logger)
    {
        _storeRepository = storeRepository;
        _ownerRepository = ownerRepository;
        _logger = logger;
        _mapper = MapperConfig.InitializeAutomapper();
    }

    public async Task<IEnumerable<StoreDTO>> GetAllStores()
    {
        var stores = await _storeRepository.GetAllAsync();
        var storesDto = _mapper.Map<IEnumerable<StoreDTO>>(stores);

        return storesDto;
    }

    public async Task<StoreDTO> AddStore(StoreCreateDTO createStoreData)
    {
        var owner = await _ownerRepository.GetOneByIdAsync(createStoreData.OwnerId);

        if (owner == null) throw new KeyNotFoundException($"Owner does not exist");
        if (owner?.Store != null) throw new InvalidOperationException($"{owner.Fullname} has a store already");

        var store = _mapper.Map<Store>(createStoreData);

        var createdStore = await _storeRepository.CreateAsync(store);
        var createdStoreDto = _mapper.Map<StoreDTO>(createdStore);

        return createdStoreDto;
    }

    public async Task<StoreDTO?> GetStoreById(int storeId)
    {
        var store = await _storeRepository.GetOneByIdAsync(storeId);

        if (store == null) throw new KeyNotFoundException("Store not found");

        return store;
    }

    public async Task<StoreDTO?> UpdateStore(int storeId, StoreUpdateDTO data)
    {
        await GetStoreById(storeId);
        var updatedStore = await _storeRepository.UpdateAsync(storeId, data);

        return updatedStore;
    }

    public async Task<StoreDTO> DeleteStore(int storeId)
    {
        await GetStoreById(storeId);

        var deletedStore = await _storeRepository.DeleteAsync(storeId);
        var deletedStoreDto = _mapper.Map<StoreDTO>(deletedStore);

        return deletedStoreDto;
    }
}