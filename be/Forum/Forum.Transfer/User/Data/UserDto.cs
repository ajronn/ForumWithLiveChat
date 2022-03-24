using System.Collections.Generic;
using Forum.Transfer.Post.Data;

namespace Forum.Transfer.User.Data
{
    public class UserDto
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public bool IsArchival { get; set; }

        public ICollection<PostDto> Posts { get; set; }
    }
}
