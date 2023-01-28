using Lanchonete.Domain.Models;

namespace Lanchonete.Domain.Interfaces.Repositories.Shared;

public interface IBaseRepository<T> : IDisposable where T : Entity
{
    Task<T> GetById(Guid id);
    Task<IEnumerable<T>> GetAll();
    Task Post(T entity);
    Task PostRange(IList<T> entities);
    Task Update(T entity);
    Task Remove(Guid id);
    Task<int> SaveChanges();
}
