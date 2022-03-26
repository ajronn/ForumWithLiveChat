using System.Threading.Tasks;
using Forum.Transfer.Subsection.Command;
using Forum.Transfer.Subsection.Query;
using Forum.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    [ApiController]
    public class SubsectionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubsectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.Subsection.GetList)]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllSubsectionsQuery());
            return Ok(result);
        }

        [HttpGet(ApiRoutes.Subsection.Get)]
        public async Task<IActionResult> Get(int subsectionId)
        {
            var result = await _mediator.Send(new GetSubsectionQuery(subsectionId));
            return Ok(result);
        }

        [HttpPost(ApiRoutes.Subsection.Create)]
        public async Task<IActionResult> Create([FromBody] CreateSubsectionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(ApiRoutes.Subsection.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateSubsectionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete(ApiRoutes.Subsection.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteSubsectionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
