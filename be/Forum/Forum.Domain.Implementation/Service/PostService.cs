using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Core;
using Forum.Data;
using Forum.Data.Entities;
using Forum.Domain.Interface.Repository;
using Forum.Domain.Interface.Service;
using Forum.Transfer.Post.Command;
using Forum.Transfer.Post.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Forum.Domain.Implementation.Service
{
    public class PostService : IPostService
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostService(ForumDbContext context, IMapper mapper, IPostRepository postRepository, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _postRepository = postRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PostDto> CreateAsync(CreatePostCommand command)
        {
            var userId = _httpContextAccessor.HttpContext.GetUserId();

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            var post = new Post
            {
                Content = command.Content,
                CreatedAt = DateTime.Now,
                ThreadId = command.ThreadId,
                UserId = userId,
                User = user
            };

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return _mapper.Map<PostDto>(post);
        }

        public async Task<PostDto> UpdateAsync(UpdatePostCommand command)
        {
            await _postRepository.EnsureExistsAsync(command.PostId);

            var post = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == command.PostId);

            post.Content = command.Content;
            post.EditedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return _mapper.Map<PostDto>(post);
        }

        public async Task<int> DeleteAsync(DeletePostCommand command)
        {
            await _postRepository.EnsureExistsAsync(command.PostId);

            var post = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == command.PostId);

            _context.Remove(post);
            await _context.SaveChangesAsync();
            return post.PostId;
        }
    }
}