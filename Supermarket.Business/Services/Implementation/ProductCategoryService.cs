using Supermarket.Business.Services.Interface;
using Supermarket.Data.Repository.Interface;
using Supermarket.Domain.Entities;

namespace Supermarket.Business.Services.Implementation;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductCategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<ProductCategory>> GetAllCategories()
    {
        var categories = await _unitOfWork.ProductCategory.GetAllAsync();
        return categories.ToList();
    }
    
    public async Task CreateCategory()
    {
        
    }
}