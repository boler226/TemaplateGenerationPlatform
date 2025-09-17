using TemaplateGenerationPlatform.Domain.Entity;

namespace TemaplateGenerationPlatform.Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
