using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Forum.Transfer.Section.Command;
using Forum.Transfer.Section.Query;
using MediatR;

namespace Forum.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllSectionsQuery());
            return Ok(result);
        }

        [HttpGet("{sectionId}")]
        public async Task<IActionResult> Get(int sectionId)
        {
            var result = await _mediator.Send(new GetSectionQuery(sectionId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSectionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSectionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteSectionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
