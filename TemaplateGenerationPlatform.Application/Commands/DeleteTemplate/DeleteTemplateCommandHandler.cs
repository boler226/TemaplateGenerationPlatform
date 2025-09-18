using MediatR;
using TemaplateGenerationPlatform.Domain.Entity;
using TemaplateGenerationPlatform.Domain.Interfaces.Repositories;
using TemaplateGenerationPlatform.Infrastructure.DbContext;

namespace TemaplateGenerationPlatform.Application.Commands.DeleteTemplate
{
    public class DeleteTemplateCommandHandler(IRepository<TemplateEntity> repository, AppDbContext context) : IRequestHandler<DeleteTemplateCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteTemplateCommand command, CancellationToken cancellationToken)
        {
            var template = await repository.GetByIdAsync(command.Id, cancellationToken)
                ?? throw new Exception("Not found");

            repository.Delete(template);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
