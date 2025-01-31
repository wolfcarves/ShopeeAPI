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

    public async Task<Owner> GetOneOwnerById(int id)
    {
        return await _ownerRepository.GetOneByIdAsync(id);
    }

    public async Task<Owner> AddOwner(OwnerCreateDTO ownerData)
    {
        if (ownerData == null)
        {
            throw new ArgumentNullException("Body cannot be null");
        }

        var createOwner = _mapper.Map<Owner>(ownerData);
        return await _ownerRepository.CreateAsync(createOwner);
    }

    public async Task<Owner> UpdateOwner(int id, OwnerUpdateDTO ownerUpdatedData)
    {
        if (id <= 0 || ownerUpdatedData == null)
        {
            throw new ArgumentNullException("Request resource cannot be null");
        }

        var owner = await _ownerRepository.GetOneByIdAsync(id);

        var updateOwner = new Owner
        {
            Fullname = ownerUpdatedData.Fullname,
            Username = owner.Username
        };

        return await _ownerRepository.UpdateAsync(id, updateOwner);
    }

    public async Task<Owner> DeleteOwner(int id)
    {
        return await _ownerRepository.DeleteAsync(id);
    }
}