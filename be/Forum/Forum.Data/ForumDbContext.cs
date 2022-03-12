using Forum.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data
{
    public class ForumDbContext : IdentityDbContext<User>
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
