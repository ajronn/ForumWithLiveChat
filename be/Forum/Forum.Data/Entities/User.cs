using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Forum.Data.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Post> Posts { get; set; }
    }
}