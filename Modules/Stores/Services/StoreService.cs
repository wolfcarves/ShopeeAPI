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
    private readonly IMapper _mapper;

    public StoreService(IStoreRepository storeRepository, IOwnerRepository ownerRepository)
    {
        _storeRepository = storeRepository;
        _ownerRepository = ownerRepository;
        _mapper = MapperConfig.InitializeAutomapper();
    }

    public async Task<IEnumerable<Store>> GetAllStores()
    {
        return await _storeRepository.GetAllAsync();
    }

    public async Task<Store> AddStore(StoreCreateDTO createStoreData)
    {
        var existingStore = await _ownerRepository.GetOneByIdAsync(createStoreData.OwnerId);

        var store = _mapper.Map<Store>(createStoreData);
        return await _storeRepository.CreateAsync(store);
    }

    public async Task<Store> GetStore(int ownerId)
    {
        return await _storeRepository.GetOneByIdAsync(ownerId);
    }


}