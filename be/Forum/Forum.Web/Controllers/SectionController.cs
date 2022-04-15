using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Forum.Transfer.Section.Command;
using Forum.Transfer.Section.Query;
using Forum.Transfer.Shared;
using Forum.Web.Infrastructure;
using MediatR;

namespace Forum.Web.Controllers
{
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.Section.GetList)]
        public async Task<IActionResult> List()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(new GetAllSectionsQuery());

            return Ok(result.ToResponseDto());
        }

        [HttpGet(ApiRoutes.Section.Get)]
        public async Task<IActionResult> Get(int sectionId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(new GetSectionQuery(sectionId));

            return Ok(result.ToResponseDto());
        }

        [HttpPost(ApiRoutes.Section.Create)]
        public async Task<IActionResult> Create([FromBody] CreateSectionCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }

        [HttpPut(ApiRoutes.Section.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateSectionCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }

        [HttpDelete(ApiRoutes.Section.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteSectionCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }
    }
}
