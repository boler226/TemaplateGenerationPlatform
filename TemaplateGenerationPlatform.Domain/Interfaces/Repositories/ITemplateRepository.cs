using TemaplateGenerationPlatform.Domain.Entity;

namespace TemaplateGenerationPlatform.Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(T entity, CancellationToken cancellationToken);
        void Update(T entity);
        void Delete(T entity);
    }
}
