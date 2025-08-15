using Supermarket.Domain.Entities;

namespace Supermarket.Data.Repository.Interface;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> GetProductsByCategoryId(int categoryId);
}