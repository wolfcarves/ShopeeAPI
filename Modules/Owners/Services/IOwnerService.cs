using ShopeeAPI.Modules.Owners.DTO;
using ShopeeAPI.Modules.Owners.Entities;

namespace ShopeeAPI.Modules.Owners.Services;

public interface IOwnerService
{
    Task<IEnumerable<Owner>> GetAllOwners();
    Task<Owner> GetOneOwnerById(int id);
    Task<Owner> AddOwner(OwnerCreateDTO owner);
    Task<Owner> UpdateOwner(int id, OwnerUpdateDTO owner);
    Task<Owner> DeleteOwner(int id);
}