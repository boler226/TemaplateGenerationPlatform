using MediatR;
using TemaplateGenerationPlatform.Application.DTOs.Template;

namespace TemaplateGenerationPlatform.Application.Queries.GetAllTemplates
{
    public record GetAllTemplatesQuery() : IRequest<List<TemplateDto>>;
}
