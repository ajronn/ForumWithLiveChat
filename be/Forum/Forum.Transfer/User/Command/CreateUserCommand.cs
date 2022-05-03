using System.ComponentModel.DataAnnotations;
using Forum.Transfer.User.Data;
using MediatR;

namespace Forum.Transfer.User.Command
{
    public class CreateUserCommand : IRequest<UserBasicDto>
    {
        [Required] public string Email { get; set; }

        [Required] public string UserName { get; set; }

        [Required] public string Password { get; set; }
    }
}
