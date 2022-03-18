using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Transfer.Post.Query;
using MediatR;

namespace Forum.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllPostsQuery());
            return Ok(result);
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> Get(int postId)
        {
            var result = await _mediator.Send(new GetPostQuery(postId));
            return Ok(result);
        }
    }
}
