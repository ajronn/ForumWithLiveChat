using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Service;
using Forum.Transfer.Role.Command;
using Forum.Transfer.Role.Data;
using MediatR;

namespace Forum.Handler.Role
{
    public class RoleCommandHandler : IRequestHandler<CreateRoleCommand, RoleDto>,
        IRequestHandler<UpdateRoleCommand, RoleDto>, IRequestHandler<DeleteRoleCommand, string>
    {
        private readonly IRoleService _roleService;

        public RoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<RoleDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await _roleService.CreateAsync(request);
        }

        public async Task<RoleDto> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            return await _roleService.UpdateAsync(request);
        }

        public async Task<string> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            return await _roleService.DeleteAsync(request);
        }
    }
}
