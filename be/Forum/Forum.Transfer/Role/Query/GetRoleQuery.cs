using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Role.Data;
using MediatR;

namespace Forum.Transfer.Role.Query
{
    public class GetRoleQuery : IRequest<RoleDto>
    {
        [Required] public string RoleId { get; set; }

        public GetRoleQuery(string roleId)
        {
            RoleId = roleId;
        }
    }
}
