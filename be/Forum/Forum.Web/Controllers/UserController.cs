using System.Threading.Tasks;
using Forum.Transfer.Post.Query;
using Forum.Transfer.Shared;
using Forum.Transfer.User.Command;
using Forum.Transfer.User.Query;
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

        [HttpGet(ApiRoutes.User.GetList)]
        public async Task<IActionResult> List()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(new GetAllUsersQuery());

            return Ok(result.ToResponseDto());
        }

        [HttpGet(ApiRoutes.User.Get)]
        public async Task<IActionResult> Get(string userId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(new GetUserQuery(userId));

            return Ok(result.ToResponseDto());
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

        [HttpPatch(ApiRoutes.User.UpdateUser)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _mediator.Send(command);
            return Ok(result.ToResponseDto());
        }

        [HttpPatch(ApiRoutes.User.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }
    }
}
