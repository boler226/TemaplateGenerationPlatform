using AutoMapper;
using MediatR;
using TemaplateGenerationPlatform.Application.Commands.Template;
using TemaplateGenerationPlatform.Application.DTOs.Template;
using TemaplateGenerationPlatform.Domain.Entity;
using TemaplateGenerationPlatform.Domain.Interfaces.Repositories;
using TemaplateGenerationPlatform.Infrastructure.DbContext;

namespace TemaplateGenerationPlatform.Application.Commands.CreateTemplate
{
    public class CreateTemplateCommandHandler(
        IRepository<TemplateEntity> repository,
        AppDbContext context,
        IMapper mapper
        ) : IRequestHandler<CreateTemplateCommand, TemplateDto>
    {
        public async Task<TemplateDto> Handle(CreateTemplateCommand command, CancellationToken cancellationToken)
        {
            var template = new TemplateEntity
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                HtmlContent = command.HtmlContent,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            };

            await repository.CreateAsync(template, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<TemplateDto>(template);
        }
    }
}
