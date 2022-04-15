using System.Threading.Tasks;
using Forum.Transfer.Shared;
using Forum.Transfer.User.Command;
using Forum.Transfer.User.Data;

namespace Forum.Domain.Interface.Service
{
    public interface IUserService
    {
        Task<UserBasicDto> CreateAsync(CreateUserCommand command);
        Task<UserBasicDto> UpdateAsync(UpdateUserCommand command);
        Task<SessionDto> Login(LoginCommand command);
        Task<UserBasicDto> ActivateAsync(ActivateUserCommand command);
        Task<UserBasicDto> DeactivateAsync(DeactivateUserCommand command);
        Task<UserBasicDto> ArchiveAsync(ArchiveUserCommand command);
        Task<UserBasicDto> DearchiveAsync(DearchiveUserCommand command);
        Task<EmptyDto> ChangePassword(ChangePasswordCommand command);
    }
}
