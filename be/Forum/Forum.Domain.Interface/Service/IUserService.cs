using System.Threading.Tasks;
using Forum.Transfer.User.Command;
using Forum.Transfer.User.Data;

namespace Forum.Domain.Interface.Service
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(CreateUserCommand command);
        Task<SessionDto> Login(LoginCommand command);
        Task<UserDto> ActivateAsync(ActivateUserCommand command);
        Task<UserDto> DeactivateAsync(DeactivateUserCommand command);
        Task<UserDto> ArchiveAsync(ArchiveUserCommand command);
        Task<UserDto> DearchiveAsync(DearchiveUserCommand command);
    }
}
