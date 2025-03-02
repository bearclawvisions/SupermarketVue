namespace Supermarket.Data.Repository.Interface;

public interface IUnitOfWork
{
    IProductRepository Product { get; }
    Task SaveChangesAsync();
}