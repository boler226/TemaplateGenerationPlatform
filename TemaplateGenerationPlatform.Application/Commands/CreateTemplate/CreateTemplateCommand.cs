using MediatR;

namespace TemaplateGenerationPlatform.Application.Commands.Template
{
    public record CreateTemplateCommand(string Name, string HtmlContent) : IRequest<Guid>;
}
