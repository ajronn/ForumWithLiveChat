using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Core;
using Forum.Core.Enums;
using Forum.Data;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Post.Data;
using Microsoft.EntityFrameworkCore;

namespace Forum.Domain.Implementation.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;

        public PostRepository(ForumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> ExistsAsync(int postId)
        {
            return _context.Posts
                .AnyAsync(x => x.PostId == postId);
        }

        public async Task EnsureExistsAsync(int postId)
        {
            if (!await ExistsAsync(postId))
            {
                throw new ForumException(ForumErrorCode.PostNotFound);
            }
        }


        public async Task<List<PostDto>> GetPostListAsync()
        {
            var posts = await _context.Posts
                .ToListAsync();

            return _mapper.Map<List<PostDto>>(posts);
        }

        public async Task<PostDto> GetPostAsync(int postId)
        {
            var post = await _context.Posts
                .Where(x => x.PostId == postId)
                .FirstOrDefaultAsync();

            return _mapper.Map<PostDto>(post);
        }
    }
}