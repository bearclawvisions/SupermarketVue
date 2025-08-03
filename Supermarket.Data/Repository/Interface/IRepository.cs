using Microsoft.EntityFrameworkCore;

namespace Supermarket.Data.Repository.Interface;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task CreateAsync(TEntity entity);
    public DbSet<TEntity> Read();
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void DeleteRange(IEnumerable<TEntity> entities);
}