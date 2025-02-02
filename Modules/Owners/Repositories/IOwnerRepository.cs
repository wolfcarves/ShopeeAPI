using ShopeeAPI.Modules.Owners.DTO;
using ShopeeAPI.Modules.Owners.Entities;

namespace ShopeeAPI.Modules.Owners.Repositories;

public interface IOwnerRepository
{
    Task<IEnumerable<OwnerDTO>> GetAllAsync();
    Task<Owner?> GetOneByIdAsync(int ownerId);
    Task<Owner?> GetOneByUsernameAsync(string username);
    Task<Owner> CreateAsync(Owner owner);
    Task<Owner?> UpdateAsync(int ownerId, Owner owner);
    Task<Owner> DeleteAsync(int ownerId);
}