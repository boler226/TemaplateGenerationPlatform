using MediatR;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using TemaplateGenerationPlatform.Domain.Entity;
using TemaplateGenerationPlatform.Domain.Interfaces.Repositories;

namespace TemaplateGenerationPlatform.Application.Commands.GeneratePdf
{
    public class GeneratePdfCommandHandler(
        IRepository<TemplateEntity> repository,
        IBrowser browser
        ) : IRequestHandler<GeneratePdfCommand, byte[]>
    {
        public async Task<byte[]> Handle(GeneratePdfCommand command, CancellationToken cancellationToken)
        {
            var template = await repository.GetByIdAsync(command.TemplateId, cancellationToken)
                ?? throw new Exception("Not found");

            string html = template.HtmlContent;

            foreach (var kv in command.Data)
            {
                html = html.Replace($"{{{{{kv.Key}}}}}", kv.Value);
            }

            await using var page = await browser.NewPageAsync();
            await page.SetContentAsync(html);

            var pdf = await page.PdfDataAsync(new PdfOptions
            {
                Format = PaperFormat.A4,
                PrintBackground = true,
                PreferCSSPageSize = true
            });

            return pdf;
        }
    }
}
