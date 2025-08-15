using Microsoft.EntityFrameworkCore;
using Supermarket.Data.Database;
using Supermarket.Data.Repository.Interface;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.Repository.Implementation;

public class ProductRepository(SuperContext context) : Repository<Product>(context), IProductRepository
{
    private readonly SuperContext _context = context;

    public async Task<List<Product>> GetProductsByCategoryId(int categoryId)
    {
        return await _context.Products
            .Where(p => p.CategoryId == categoryId)
            .ToListAsync();
    }
}