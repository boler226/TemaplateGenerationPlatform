using MediatR;
using TemaplateGenerationPlatform.Domain.Entity;
using TemaplateGenerationPlatform.Domain.Interfaces.Repositories;
using TemaplateGenerationPlatform.Infrastructure.DbContext;

namespace TemaplateGenerationPlatform.Application.Commands.UpdateTemplate
{
    public class UpdateTemplateCommandHandler(IRepository<TemplateEntity> repository, AppDbContext context) : IRequestHandler<UpdateTemplateCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateTemplateCommand command, CancellationToken cancellationToken)
        {
            var template = await repository.GetByIdAsync(command.Id, cancellationToken)
                ?? throw new Exception("Not found");

           if (!string.IsNullOrWhiteSpace(command.Name))
                template.Name = command.Name;

           if (!string.IsNullOrWhiteSpace(command.HtmlContent))
                template.HtmlContent = command.HtmlContent;

            template.UpdatedAt = DateTime.UtcNow;

            repository.Update(template);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
