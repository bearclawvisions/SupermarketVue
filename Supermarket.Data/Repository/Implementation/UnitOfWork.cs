using Supermarket.Data.Database;
using Supermarket.Data.Repository.Interface;

namespace Supermarket.Data.Repository.Implementation;

public class UnitOfWork : IUnitOfWork
{
    private readonly SuperContext _context;
    public IProductRepository Product { get; }
    public IAppUserRepository AppUser { get; }

    public UnitOfWork(SuperContext context)
    {
        _context = context;
        Product = new ProductRepository(_context);
        AppUser = new AppUserRepository(_context);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}