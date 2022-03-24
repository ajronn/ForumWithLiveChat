using System.ComponentModel.DataAnnotations;
using Forum.Transfer.User.Data;
using MediatR;

namespace Forum.Transfer.User.Command
{
    public class LoginCommand : IRequest<SessionDto>
    {
        [Required] public string Email { get; set; }

        [Required] public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
