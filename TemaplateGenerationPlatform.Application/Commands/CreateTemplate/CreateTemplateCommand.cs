using MediatR;
using TemaplateGenerationPlatform.Application.DTOs.Template;

namespace TemaplateGenerationPlatform.Application.Commands.Template
{
    public record CreateTemplateCommand(string Name, string HtmlContent) : IRequest<TemplateDto>;
}
