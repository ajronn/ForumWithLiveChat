using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Shared;
using MediatR;

namespace Forum.Transfer.User.Command
{
    public class ChangePasswordCommand : IRequest<EmptyDto>
    {
        [Required] public string Id { get; set; }

        [Required] public string OldPassword { get; set; }

        [Required] public string NewPassword { get; set; }
    }
}
