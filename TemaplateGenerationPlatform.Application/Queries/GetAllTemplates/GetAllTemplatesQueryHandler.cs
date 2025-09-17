using AutoMapper;
using MediatR;
using TemaplateGenerationPlatform.Application.DTOs.Template;
using TemaplateGenerationPlatform.Domain.Entity;
using TemaplateGenerationPlatform.Domain.Interfaces.Repositories;

namespace TemaplateGenerationPlatform.Application.Queries.GetAllTemplates
{
    public class GetAllTemplatesQueryHandler(IRepository<TemplateEntity> repository, IMapper mapper) : IRequestHandler<GetAllTemplatesQuery, List<TemplateDto>>
    {
        public async Task<List<TemplateDto>> Handle(GetAllTemplatesQuery query, CancellationToken cancellationToken)
        {
            var templates = await repository.GetAllAsync(cancellationToken);

            return mapper.Map<List<TemplateDto>>(templates);
        }
    }
}
