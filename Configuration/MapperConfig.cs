using AutoMapper;
using ShopeeAPI.Modules.Owners.Mapping;

namespace ShopeeAPI.Configuration;
public class MapperConfig
{
    public static Mapper InitializeAutomapper()
    {
        var config = new MapperConfiguration(cfg =>
            cfg.AddProfile<OwnerProfile>()
        );

        var mapper = new Mapper(config);

        return mapper;
    }
}