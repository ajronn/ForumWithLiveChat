using System.Threading.Tasks;
using Forum.Transfer.Subsection.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubsectionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubsectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllSubsectionsQuery());
            return Ok(result);
        }

        [HttpGet("{subsectionId}")]
        public async Task<IActionResult> Get(int subsectionId)
        {
            var result = await _mediator.Send(new GetSubsectionQuery(subsectionId));
            return Ok(result);
        }
    }
}
