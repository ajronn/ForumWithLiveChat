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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Forum.Web.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ThreadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ThreadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Thread.GetList)]
        public async Task<IActionResult> List()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(new GetAllThreadsQuery());

            return Ok(result.ToResponseDto());
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Thread.Get)]
        public async Task<IActionResult> Get(int threadId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(new GetThreadQuery(threadId));

            return Ok(result.ToResponseDto());
        }

        [HttpPost(ApiRoutes.Thread.Create)]
        public async Task<IActionResult> Create([FromBody] CreateThreadCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut(ApiRoutes.Thread.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateThreadCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete(ApiRoutes.Thread.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteThreadCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }
    }
}
