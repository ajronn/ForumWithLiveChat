using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Core;
using Forum.Core.Enums;
using Forum.Data;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Post.Data;
using Forum.Transfer.User.Data;
using Microsoft.EntityFrameworkCore;

namespace Forum.Domain.Implementation.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ForumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> ExistsAsync(string userId)
        {
            return _context.Users
                .AnyAsync(x => x.Id == userId);
        }

        public async Task EnsureExistsAsync(string userId)
        {
            if (!await ExistsAsync(userId))
            {
                throw new ForumException(ForumErrorCode.UserNotFound);
            }
        }


        public async Task<List<UserBasicDto>> GetUserListAsync()
        {
            var posts = await _context.Users
                .ToListAsync();

            return _mapper.Map<List<UserBasicDto>>(posts);
        }

        public async Task<UserDto> GetUserAsync(string userId)
        {
            var post = await _context.Users
                .Where(x => x.Id == userId)
                .FirstOrDefaultAsync();

            return _mapper.Map<UserDto>(post);
        }
    }
}
