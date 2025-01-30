using ShopeeAPI.Modules.Owners.Entities;

namespace ShopeeAPI.Modules.Owners.Repositories;

public interface IOwnerRepository
{
    Task<IEnumerable<Owner>> GetAllAsync();
    // Task<Owner> GetOneAsync(int ownerId);
    // Task<Owner> CreateAsync(Owner owner);
    // Task<Owner> UpdateAsync(int id, Owner owner);
    // Task<Owner> DeleteAsync(int id);
}