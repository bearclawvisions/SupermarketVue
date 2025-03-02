using Supermarket.Data.Database;
using Supermarket.Data.Repository.Interface;

namespace Supermarket.Data.Repository.Implementation;

public class UnitOfWork : IUnitOfWork
{
    private readonly SuperContext _context;
    public IProductRepository Product { get; }

    public UnitOfWork(SuperContext context)
    {
        _context = context;
        Product = new ProductRepository(_context);
    }

    public void SaveChangesAsync()
    {
        _context.SaveChangesAsync();
    }
}