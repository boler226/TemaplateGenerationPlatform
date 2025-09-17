using MediatR;

namespace TemaplateGenerationPlatform.Application.Commands.UpdateTemplate
{
    public record UpdateTemplateCommand(Guid Id, string? Name, string? HtmlContent) : IRequest<Unit>;
}
