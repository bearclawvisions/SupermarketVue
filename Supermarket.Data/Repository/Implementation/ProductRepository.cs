using Supermarket.Data.Database;
using Supermarket.Data.Repository.Interface;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.Repository.Implementation;

public class ProductRepository(SuperContext context) : Repository<Product>(context), IProductRepository
{
    private readonly SuperContext _context = context;
}