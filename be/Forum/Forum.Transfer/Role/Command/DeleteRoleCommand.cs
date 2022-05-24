using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Forum.Transfer.Role.Command
{
    public class DeleteRoleCommand : IRequest<string>
    {
        [Required] public string RoleId { get; set; }
    }
}
