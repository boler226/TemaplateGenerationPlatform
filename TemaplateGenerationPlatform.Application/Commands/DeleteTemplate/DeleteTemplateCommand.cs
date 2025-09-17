using MediatR;

namespace TemaplateGenerationPlatform.Application.Commands.DeleteTemplate
{
    public record DeleteTemplateCommand(Guid Id) : IRequest<Unit>;
}
