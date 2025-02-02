using System.Text.Json;
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


    public async Task<IEnumerable<Store>> GetAllStores()
    {
        return await _storeRepository.GetAllAsync();
    }

    public async Task<Store> AddStore(StoreCreateDTO createStoreData)
    {
        var owner = await _ownerRepository.GetOneByIdAsync(createStoreData.OwnerId);

        if (owner.Store != null) throw new InvalidOperationException($"{owner.Fullname} has a store already");

        var store = _mapper.Map<Store>(createStoreData);

        return await _storeRepository.CreateAsync(store);
    }

    public async Task<StoreDTO?> GetStoreById(int storeId)
    {
        var store = await _storeRepository.GetOneByIdAsync(storeId);

        if (store == null) throw new KeyNotFoundException("Store not found");

        return store;
    }


}