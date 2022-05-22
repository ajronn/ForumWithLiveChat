using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Role.Data;
using Forum.Transfer.Role.Query;
using MediatR;

namespace Forum.Handler.Role
{
    public class RoleQueryHandler : IRequestHandler<GetAllRolesQuery, List<RoleDto>>,
        IRequestHandler<GetRoleQuery, RoleDto>
    {
        private readonly IRoleRepository _roleRepository;

        public RoleQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return await _roleRepository.GetRoleListAsync();
        }

        public async Task<RoleDto> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            return await _roleRepository.GetRoleAsync(request.RoleId);
        }
    }
}
