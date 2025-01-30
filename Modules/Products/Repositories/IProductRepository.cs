using ShopeeAPI.Modules.Products.Models;

namespace ShopeeAPI.Modules.Products.Repositories;

public interface IProductRepository
{
    Task<Product> GetProduct();
}