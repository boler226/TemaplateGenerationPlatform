using Microsoft.EntityFrameworkCore;
using TemaplateGenerationPlatform.Domain.Entity;

namespace TemaplateGenerationPlatform.Infrastructure.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<TemplateEntity> Templates { get; set; }
    }
}
