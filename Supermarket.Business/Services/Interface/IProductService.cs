using Supermarket.Domain.Entities;

namespace Supermarket.Business.Services.Interface;

public interface IProductService
{
    Task<List<Product>> GetAllProductsForCategory(int categoryId);
    Task CreateProduct();
    Task UpdateProduct();
    Task DeleteProduct();
}