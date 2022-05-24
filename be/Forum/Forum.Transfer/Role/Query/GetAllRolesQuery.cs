using System.Collections.Generic;
using Forum.Transfer.Role.Data;
using MediatR;

namespace Forum.Transfer.Role.Query
{
    public class GetAllRolesQuery : IRequest<List<RoleDto>>
    {
    }
}
