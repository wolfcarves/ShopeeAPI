using AutoMapper;
using ShopeeAPI.Configuration;
using ShopeeAPI.Modules.Stores.DTO;
using ShopeeAPI.Modules.Stores.Entities;
using ShopeeAPI.Modules.Stores.Repositories;

namespace ShopeeAPI.Modules.Stores.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;
    private readonly IMapper _mapper;

    public StoreService(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
        _mapper = MapperConfig.InitializeAutomapper();
    }

    public async Task<IEnumerable<Store>> GetAllStores()
    {
        return await _storeRepository.GetAllAsync();
    }

    public async Task<Store> AddStore(StoreCreateDTO createStoreData)
    {
        if (createStoreData == null) throw new ArgumentNullException("Body cannot be null");
        if (createStoreData.OwnerId == null) throw new ArgumentNullException("OwnerId cannot be null");

        var store = _mapper.Map<Store>(createStoreData);
        return await _storeRepository.CreateAsync(store);
    }
}