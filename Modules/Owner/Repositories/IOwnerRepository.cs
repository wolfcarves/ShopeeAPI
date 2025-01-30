using ShopeeAPI.Modules.Owner.Entities;

public interface IOwnerRepository
{
    Task<IEnumerable<Owner>> GetAllAsync();
    Task<Owner> GetOneAsync(int ownerId);
    Task<Owner> CreateAsync(Owner owner);
    Task<Owner> UpdateAsync(int id, Owner owner);
    Task<Owner> DeleteAsync(int id);
}