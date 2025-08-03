using Supermarket.Data.Database;
using Supermarket.Data.Repository.Interface;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.Repository.Implementation;

public class ProductCategoryRepository(SuperContext context) : Repository<ProductCategory>(context), IProductCategoryRepository
{
    private readonly SuperContext _context = context;
}