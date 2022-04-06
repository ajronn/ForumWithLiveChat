using System.Threading.Tasks;
using Forum.Transfer.Shared;
using Forum.Transfer.User.Command;
using Forum.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiRoutes.User.Register)]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _mediator.Send(command);
            return Ok(result.ToResponseDto());
        }

        [HttpPost(ApiRoutes.User.Login)]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _mediator.Send(command);
            return Ok(result.ToResponseDto());
        }

        [HttpPatch(ApiRoutes.User.ActivateUser)]
        public async Task<IActionResult> ActivateUser(ActivateUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }

        [HttpPatch(ApiRoutes.User.DeactivateUser)]
        public async Task<IActionResult> DeactivateUser(DeactivateUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }

        [HttpPatch(ApiRoutes.User.ArchiveUser)]
        public async Task<IActionResult> ArchiveUser(ArchiveUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }

        [HttpPatch(ApiRoutes.User.DearchiveUser)]
        public async Task<IActionResult> DearchiveUser(DearchiveUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }
    }
}
