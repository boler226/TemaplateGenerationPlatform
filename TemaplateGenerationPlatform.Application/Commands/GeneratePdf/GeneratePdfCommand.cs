using MediatR;

namespace TemaplateGenerationPlatform.Application.Commands.GeneratePdf
{
    public record GeneratePdfCommand(Guid TemplateId, Dictionary<string, string> Data) : IRequest<byte[]>;
}
