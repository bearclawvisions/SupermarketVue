using Supermarket.Domain.Entities;

namespace Supermarket.Business.Services.Interface;

public interface IProductCategoryService
{
    Task<List<ProductCategory>> GetAllCategories();
    Task CreateCategory();
}