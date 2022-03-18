using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Transfer.Thread.Query;
using MediatR;

namespace Forum.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ThreadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllThreadsQuery());
            return Ok(result);
        }

        [HttpGet("{threadId}")]
        public async Task<IActionResult> Get(int threadId)
        {
            var result = await _mediator.Send(new GetThreadQuery(threadId));
            return Ok(result);
        }
    }
}
