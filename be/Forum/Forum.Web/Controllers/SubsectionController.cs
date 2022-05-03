using System.Threading.Tasks;
using Forum.Transfer.Shared;
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
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(new GetAllSubsectionsQuery());

            return Ok(result.ToResponseDto());
        }

        [HttpGet(ApiRoutes.Subsection.Get)]
        public async Task<IActionResult> Get(int subsectionId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(new GetSubsectionQuery(subsectionId));

            return Ok(result.ToResponseDto());
        }

        [HttpPost(ApiRoutes.Subsection.Create)]
        public async Task<IActionResult> Create([FromBody] CreateSubsectionCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }

        [HttpPut(ApiRoutes.Subsection.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateSubsectionCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }

        [HttpDelete(ApiRoutes.Subsection.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteSubsectionCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }
    }
}
