namespace Supermarket.Data.Repository.Interface;

public interface IUnitOfWork
{
    IProductRepository Product { get; }
    IAppUserRepository AppUser { get; }
    IProductCategoryRepository ProductCategory { get; }
    Task SaveChangesAsync();
}