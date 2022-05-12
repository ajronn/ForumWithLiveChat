using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Forum.Domain.Implementation.Service;
using Forum.Domain.Interface.Service;
using Forum.Transfer.Chat.Command;
using Forum.Transfer.Chat.Query;
using Forum.Transfer.Shared;
using Forum.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Forum.Web.Controllers
{
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHubContext<ChatHub, IChatClient> _hubContext;

        public ChatController(IMediator mediator, IHubContext<ChatHub, IChatClient> hubContext)
        {
            _mediator = mediator;
            _hubContext = hubContext;
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

        [HttpPost(ApiRoutes.Message.Create)]
        public async Task<IActionResult> Create([FromBody] CreateMessageCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);
            await _hubContext.Clients.All.ReceiveMessage(result);
            return Ok(result.ToResponseDto());
        }
    }
}
