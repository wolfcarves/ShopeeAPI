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

    public async Task<IEnumerable<OwnerDTO>> GetAllOwners()
    {
        var owners = await _ownerRepository.GetAllAsync();
        var ownersDto = _mapper.Map<IEnumerable<OwnerDTO>>(owners);

        return ownersDto;
    }

    public async Task<OwnerDTO> GetOneOwnerById(int id)
    {
        var owner = await _ownerRepository.GetOneByIdAsync(id);

        if (owner == null) throw new KeyNotFoundException("This owner doesn't exists");

        var ownerDto = _mapper.Map<OwnerDTO>(owner);

        return ownerDto;
    }

    public async Task<OwnerDTO> AddOwner(OwnerCreateDTO ownerData)
    {
        var existingOwner = await _ownerRepository.GetOneByUsernameAsync(ownerData.Username);

        if (existingOwner != null)
        {
            throw new InvalidOperationException("Username already exists");
        }

        var createOwnerData = _mapper.Map<Owner>(ownerData);
        var createdOwnerDto = await _ownerRepository.CreateAsync(createOwnerData);
        var ownerDto = _mapper.Map<OwnerDTO>(createdOwnerDto);

        return ownerDto;
    }

    public async Task<OwnerDTO> UpdateOwner(int ownerId, OwnerUpdateDTO ownerUpdatedData)
    {
        var owner = await _ownerRepository.GetOneByIdAsync(ownerId);

        if (owner == null) throw new KeyNotFoundException($"Owner doesn't exists");

        var updateOwner = new Owner
        {
            Fullname = ownerUpdatedData.Fullname,
            Username = owner.Username
        };

        var updatedOwner = await _ownerRepository.UpdateAsync(ownerId, updateOwner);
        var ownerDto = _mapper.Map<OwnerDTO>(updatedOwner);

        return ownerDto;
    }

    public async Task<OwnerDTO> DeleteOwner(int ownerId)
    {
        await GetOneOwnerById(ownerId);

        var deletedOwner = await _ownerRepository.DeleteAsync(ownerId);
        var deletedOwnerDto = _mapper.Map<OwnerDTO>(deletedOwner);
        return deletedOwnerDto;
    }
}