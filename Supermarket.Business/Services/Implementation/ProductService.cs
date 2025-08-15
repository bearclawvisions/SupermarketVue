using Supermarket.Business.Services.Interface;
using Supermarket.Data.Repository.Interface;
using Supermarket.Domain.Entities;

namespace Supermarket.Business.Services.Implementation;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<Product>> GetAllProductsForCategory(int categoryId)
    {
        var result = await _unitOfWork.Product.GetProductsByCategoryId(categoryId);
        return result;
    }

    public async Task CreateProduct()
    {
        
    }
    
    public async Task UpdateProduct()
    {
        
    }
    
    public async Task DeleteProduct()
    {
        
    }
}