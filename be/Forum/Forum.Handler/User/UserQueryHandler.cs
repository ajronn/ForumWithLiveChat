using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.User.Data;
using Forum.Transfer.User.Query;
using MediatR;

namespace Forum.Handler.User
{
    public class UserQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserBasicDto>>,
        IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public UserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserBasicDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserListAsync();
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserAsync(request.Id);
        }
    }
}
