using System.ComponentModel.DataAnnotations;

namespace Forum.Transfer.User.Command
{
    public class CreateUserCommand
    {
        [Required] public string Email { get; set; }

        [Required] public string UserName { get; set; }

        [Required] public string Password { get; set; }
    }
}
