using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Transfer.Post.Command;
using Forum.Transfer.Post.Query;
using Forum.Transfer.Shared;
using Forum.Web.Infrastructure;
using MediatR;

namespace Forum.Web.Controllers
{
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.Post.GetList)]
        public async Task<IActionResult> List()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(new GetAllPostsQuery());

            return Ok(result.ToResponseDto());
        }

        [HttpGet(ApiRoutes.Post.Get)]
        public async Task<IActionResult> Get(int postId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(new GetPostQuery(postId));

            return Ok(result.ToResponseDto());
        }

        [HttpPost(ApiRoutes.Post.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }

        [HttpPut(ApiRoutes.Post.Update)]
        public async Task<IActionResult> Update([FromBody] UpdatePostCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }

        [HttpDelete(ApiRoutes.Post.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeletePostCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }
    }
}
