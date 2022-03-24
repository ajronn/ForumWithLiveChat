using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Service;
using Forum.Transfer.User.Command;
using Forum.Transfer.User.Data;
using MediatR;

namespace Forum.Handler.User
{
    public class UserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>, IRequestHandler<LoginCommand, SessionDto>
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
    }
}
