using AutoMapper;
using ShopeeAPI.Modules.Owners.DTO;
using ShopeeAPI.Modules.Owners.Entities;

namespace ShopeeAPI.Modules.Owners.Mapping;

public class OwnerProfile : Profile
{
    public OwnerProfile()
    {
        CreateMap<OwnerCreateDTO, Owner>();
        CreateMap<OwnerUpdateDTO, Owner>();
    }
}