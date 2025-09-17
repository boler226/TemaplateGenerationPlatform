using Microsoft.EntityFrameworkCore;
using TemaplateGenerationPlatform.Domain.Entity;
using TemaplateGenerationPlatform.Domain.Interfaces.Repositories;
using TemaplateGenerationPlatform.Infrastructure.DbContext;

namespace TemaplateGenerationPlatform.Infrastructure.Repositories
{
    public class TemplateRepository(AppDbContext context) : IRepository<TemplateEntity>
    {
        public async Task<List<TemplateEntity>> GetAllAsync(CancellationToken cancellationToken) => 
            await context.Templates.ToListAsync(cancellationToken);

        public async Task<TemplateEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken) => 
            await context.Templates.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        public async Task CreateAsync(TemplateEntity entity, CancellationToken cancellationToken) =>
            await context.Templates.AddAsync(entity, cancellationToken);

        public void Update(TemplateEntity entity) =>
            context.Templates.Update(entity);

        public void Delete(TemplateEntity entity) =>
            context.Templates.Remove(entity);
    }
}
