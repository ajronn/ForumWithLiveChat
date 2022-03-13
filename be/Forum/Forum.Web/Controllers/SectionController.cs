using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllSectionQuery());
            return Ok(result);
        }
    }
}
