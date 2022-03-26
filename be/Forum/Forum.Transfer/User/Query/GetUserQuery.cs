using System.ComponentModel.DataAnnotations;
using Forum.Transfer.User.Data;
using MediatR;

namespace Forum.Transfer.User.Query
{
    public class GetUserQuery : IRequest<UserDto>
    {
        [Required] public string Id { get; set; }

        public GetUserQuery(string id)
        {
            Id = id;
        }
    }
}
