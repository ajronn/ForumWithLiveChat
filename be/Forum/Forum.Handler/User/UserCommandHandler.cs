using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Service;
using Forum.Transfer.User.Command;
using Forum.Transfer.User.Data;
using MediatR;

namespace Forum.Handler.User
{
    public class UserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>,
        IRequestHandler<LoginCommand, SessionDto>, IRequestHandler<ActivateUserCommand, UserDto>,
        IRequestHandler<DeactivateUserCommand, UserDto>, IRequestHandler<ArchiveUserCommand, UserDto>,
        IRequestHandler<DearchiveUserCommand, UserDto>
    {
        private readonly IUserService _userService;

        public UserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.CreateAsync(request);
        }

        public async Task<SessionDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _userService.Login(request);
        }

        public async Task<UserDto> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.ActivateAsync(request);
        }

        public async Task<UserDto> Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.DeactivateAsync(request);
        }

        public async Task<UserDto> Handle(ArchiveUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.ArchiveAsync(request);
        }

        public async Task<UserDto> Handle(DearchiveUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.DearchiveAsync(request);
        }
    }
}