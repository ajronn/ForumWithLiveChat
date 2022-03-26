using System.Collections.Generic;
using Forum.Transfer.User.Data;
using MediatR;

namespace Forum.Transfer.User.Query
{
    public class GetAllUsersQuery : IRequest<List<UserDto>>
    {
    }
}
