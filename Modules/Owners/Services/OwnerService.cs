using AutoMapper;
using ShopeeAPI.Configuration;
using ShopeeAPI.Modules.Owners.DTO;
using ShopeeAPI.Modules.Owners.Entities;
using ShopeeAPI.Modules.Owners.Repositories;

namespace ShopeeAPI.Modules.Owners.Services;

public class OwnerService : IOwnerService
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IMapper _mapper;

    public OwnerService(IOwnerRepository ownerRepository)
    {
        _ownerRepository = ownerRepository;
        _mapper = MapperConfig.InitializeAutomapper();
    }

    public async Task<IEnumerable<Owner>> GetAllOwners()
    {
        return await _ownerRepository.GetAllAsync();
    }

    public async Task<Owner> GetOneOwnerById(int ownerId)
    {
        return await _ownerRepository.GetOneByIdAsync(ownerId);
    }

    public async Task<Owner> AddOwner(OwnerCreateDTO owner)
    {
        var createOwner = _mapper.Map<Owner>(owner);
        return await _ownerRepository.CreateAsync(createOwner);
    }

    public async Task<Owner> UpdateOwner(int ownerId, OwnerUpdateDTO owner)
    {
        var updateOwner = _mapper.Map<Owner>(owner);

        await _ownerRepository.GetOneByIdAsync(ownerId);

        return await _ownerRepository.CreateAsync(updateOwner);
    }

    public async Task<Owner> DeleteOwner(int ownerId)
    {
        return await _ownerRepository.DeleteAsync(ownerId);
    }
}