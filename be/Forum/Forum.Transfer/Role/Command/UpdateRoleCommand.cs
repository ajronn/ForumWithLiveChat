using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Role.Data;
using MediatR;

namespace Forum.Transfer.Role.Command
{
    public class UpdateRoleCommand : IRequest<RoleDto>
    {
        [Required] public string RoleId { get; set; }
        [Required] public string Name { get; set; }
    }
}
