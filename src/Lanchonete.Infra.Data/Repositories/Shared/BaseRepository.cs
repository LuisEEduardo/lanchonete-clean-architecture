using Lanchonete.Domain.Interfaces.Repositories.Shared;
using Lanchonete.Domain.Models;
using Lanchonete.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Lanchonete.Infra.Data.Repositories.Shared;

public class BaseRepository<T> : IBaseRepository<T> where T : Entity, new()
{
    private readonly DataContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(DataContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task Post(T entity)
    {
        _dbSet.Add(entity);
        await SaveChanges();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }

    public async Task<IEnumerable<T>> GetAll()
        => await _dbSet.ToListAsync();

    public async Task<T> GetById(Guid id)
        => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

    public async Task Remove(Guid id)
    {
        _dbSet.Remove(new T { Id = id });
        await SaveChanges();
    }

    public async Task<int> SaveChanges()
        => await _context.SaveChangesAsync();

    public async Task Update(T entity)
    {
        _dbSet.Update(entity);
        await SaveChanges();
    }
}
