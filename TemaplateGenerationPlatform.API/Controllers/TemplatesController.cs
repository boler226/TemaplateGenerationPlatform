using MediatR;
using Microsoft.AspNetCore.Mvc;
using TemaplateGenerationPlatform.Application.Commands.DeleteTemplate;
using TemaplateGenerationPlatform.Application.Commands.Template;
using TemaplateGenerationPlatform.Application.Commands.UpdateTemplate;
using TemaplateGenerationPlatform.Application.Queries.GetAllTemplates;


namespace TemaplateGenerationPlatform.API.Controllers
{
    [ApiController]
    [Route("api/templates")]
    public class TemplatesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => 
            Ok(await mediator.Send(new GetAllTemplatesQuery()));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTemplateCommand command) => 
            Ok(await mediator.Send(command));

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTemplateCommand command) => 
            Ok(await mediator.Send(new UpdateTemplateCommand(id, command.Name, command.HtmlContent)));
        

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id) => 
            Ok(await mediator.Send(new DeleteTemplateCommand(id)));
    }
}
