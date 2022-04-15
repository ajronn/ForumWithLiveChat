using System.ComponentModel.DataAnnotations;
using Forum.Transfer.User.Data;
using MediatR;

namespace Forum.Transfer.User.Command
{
    public class ActivateUserCommand : IRequest<UserBasicDto>
    {
        [Required] public string Id { get; set; }
    }
}