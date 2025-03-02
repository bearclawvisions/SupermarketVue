namespace Supermarket.Data.Repository.Interface;

public interface IUnitOfWork
{
    IProductRepository Product { get; }
    void SaveChangesAsync();
}