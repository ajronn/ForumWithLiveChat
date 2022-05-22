using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Role.Data;
using MediatR;

namespace Forum.Transfer.Role.Command
{
    public class CreateRoleCommand : IRequest<RoleDto>
    {
        [Required] public string Name { get; set; }
    }
}
