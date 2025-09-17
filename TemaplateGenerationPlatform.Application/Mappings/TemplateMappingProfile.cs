using AutoMapper;
using TemaplateGenerationPlatform.Application.DTOs.Template;
using TemaplateGenerationPlatform.Domain.Entity;

namespace TemaplateGenerationPlatform.Application.Mappings
{
    public class TemplateMappingProfile : Profile
    {
        public TemplateMappingProfile()
        { 
            CreateMap<TemplateEntity, TemplateDto>();
        }
    }
}
