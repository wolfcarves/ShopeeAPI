using AutoMapper;
using ShopeeAPI.Modules.Owners.Mapping;
using ShopeeAPI.Modules.Stores.Mapping;

namespace ShopeeAPI.Configuration;

public class MapperConfig
{
    public static Mapper InitializeAutomapper()
    {
        var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<OwnerProfile>();
                cfg.AddProfile<StoreProfile>();
            }
        );

        var mapper = new Mapper(config);

        return mapper;
    }
}