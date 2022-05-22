using System.Threading.Tasks;
using Forum.Transfer.Role.Command;
using Forum.Transfer.Role.Query;
using Forum.Transfer.Shared;
using Forum.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Role.GetList)]
        public async Task<IActionResult> List()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(new GetAllRolesQuery());

            return Ok(result.ToResponseDto());
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Role.Get)]
        public async Task<IActionResult> Get(string roleId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(new GetRoleQuery(roleId));

            return Ok(result.ToResponseDto());
        }

        [HttpPost(ApiRoutes.Role.Create)]
        public async Task<IActionResult> Create([FromBody] CreateRoleCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }

        [HttpPut(ApiRoutes.Role.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateRoleCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }

        [HttpDelete(ApiRoutes.Role.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteRoleCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(command);

            return Ok(result.ToResponseDto());
        }
    }
}
