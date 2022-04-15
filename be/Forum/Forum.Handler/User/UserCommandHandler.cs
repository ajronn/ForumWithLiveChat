using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Service;
using Forum.Transfer.User.Command;
using Forum.Transfer.User.Data;
using MediatR;

namespace Forum.Handler.User
{
    public class UserCommandHandler : IRequestHandler<CreateUserCommand, UserBasicDto>,
        IRequestHandler<LoginCommand, SessionDto>, IRequestHandler<ActivateUserCommand, UserBasicDto>,
        IRequestHandler<DeactivateUserCommand, UserBasicDto>, IRequestHandler<ArchiveUserCommand, UserBasicDto>,
        IRequestHandler<DearchiveUserCommand, UserBasicDto>
    {
        private readonly IUserService _userService;

        public UserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserBasicDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.CreateAsync(request);
        }

        public async Task<SessionDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _userService.Login(request);
        }

        public async Task<UserBasicDto> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.ActivateAsync(request);
        }

        public async Task<UserBasicDto> Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.DeactivateAsync(request);
        }

        public async Task<UserBasicDto> Handle(ArchiveUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.ArchiveAsync(request);
        }

        public async Task<UserBasicDto> Handle(DearchiveUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.DearchiveAsync(request);
        }
    }
}