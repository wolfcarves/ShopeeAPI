using ShopeeAPI.Modules.Owners.DTO;

namespace ShopeeAPI.Modules.Owners.Services;

public interface IOwnerService
{
    Task<IEnumerable<OwnerDTO>> GetAllOwners();
    Task<OwnerDTO?> GetOneOwnerById(int ownerId);
    Task<OwnerDTO> AddOwner(OwnerCreateDTO owner);
    Task<OwnerDTO> UpdateOwner(int ownerId, OwnerUpdateDTO owner);
    Task<OwnerDTO> DeleteOwner(int ownerId);
}