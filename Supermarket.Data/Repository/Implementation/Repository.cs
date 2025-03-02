using Microsoft.EntityFrameworkCore;
using Supermarket.Data.Database;
using Supermarket.Data.Repository.Interface;

namespace Supermarket.Data.Repository.Implementation;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly SuperContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(SuperContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    
    public async Task CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public DbSet<TEntity> Read(TEntity entity)
    {
        return _context.Set<TEntity>();
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
    
    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}