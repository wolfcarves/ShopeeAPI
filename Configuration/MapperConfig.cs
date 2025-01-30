using AutoMapper;
using ShopeeAPI.Modules.Owners.DTO;
using ShopeeAPI.Modules.Owners.Entities;

namespace ShopeeAPI.Configuration;

public class MapperConfig
{
    public static Mapper InitializeAutomapper()
    {
        var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<Owner, OwnerCreateDTO>()
        );

        var mapper = new Mapper(config);

        return mapper;
    }
}