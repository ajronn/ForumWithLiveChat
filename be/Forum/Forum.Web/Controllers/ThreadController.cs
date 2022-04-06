using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Transfer.Shared;
using Forum.Transfer.Thread.Command;
using Forum.Transfer.Thread.Query;
using Forum.Web.Infrastructure;
using MediatR;

namespace Forum.Web.Controllers
{
    [ApiController]
    public class ThreadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ThreadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.Thread.GetList)]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllThreadsQuery());
            return Ok(result.ToResponseDto());
        }

        [HttpGet(ApiRoutes.Thread.Get)]
        public async Task<IActionResult> Get(int threadId)
        {
            var result = await _mediator.Send(new GetThreadQuery(threadId));
            return Ok(result.ToResponseDto());
        }

        [HttpPost(ApiRoutes.Thread.Create)]
        public async Task<IActionResult> Create([FromBody] CreateThreadCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result.ToResponseDto());
        }

        [HttpPut(ApiRoutes.Thread.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateThreadCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result.ToResponseDto());
        }

        [HttpDelete(ApiRoutes.Thread.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteThreadCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result.ToResponseDto());
        }
    }
}
