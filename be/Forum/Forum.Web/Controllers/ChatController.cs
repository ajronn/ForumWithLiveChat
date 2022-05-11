using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Forum.Transfer.Chat.Command;
using Forum.Transfer.Chat.Query;
using Forum.Transfer.Shared;
using Forum.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Forum.Web.Controllers
{
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMediator _mediator;
        //private readonly IHubContext<ChatService, IChatService> _hubContext;

        public ChatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Message.GetList)]
        public async Task<IActionResult> List()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(new GetAllMessagesQuery());

            return Ok(result.ToResponseDto());
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Message.Get)]
        public async Task<IActionResult> Get(int postId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(new GetMessageQuery(postId));

            return Ok(result.ToResponseDto());
        }

        [HttpPost(ApiRoutes.Post.Create)]
        public async Task<IActionResult> Create([FromBody] CreateMessageCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }
    }
}
