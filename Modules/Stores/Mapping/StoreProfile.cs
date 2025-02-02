using AutoMapper;
using ShopeeAPI.Modules.Stores.DTO;
using ShopeeAPI.Modules.Stores.Entities;

namespace ShopeeAPI.Modules.Stores.Mapping;

public class StoreProfile : Profile
{
    public StoreProfile()
    {
        CreateMap<Store, StoreDTO>();
        CreateMap<StoreCreateDTO, Store>();
    }
}
