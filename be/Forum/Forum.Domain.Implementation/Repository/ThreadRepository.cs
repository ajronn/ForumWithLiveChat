using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Core;
using Forum.Core.Enums;
using Forum.Data;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Thread.Data;
using Microsoft.EntityFrameworkCore;

namespace Forum.Domain.Implementation.Repository
{
    public class ThreadRepository : IThreadRepository
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;

        public ThreadRepository(ForumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> ExistsAsync(int threadId)
        {
            return _context.Threads
                .AnyAsync(x => x.ThreadId == threadId);
        }

        public async Task EnsureExistsAsync(int threadId)
        {
            if (!await ExistsAsync(threadId))
            {
                throw new ForumException(ForumErrorCode.ThreadNotFound);
            }
        }


        public async Task<List<ThreadDto>> GetThreadListAsync()
        {
            var threads = await _context.Threads
                .Include(x => x.Posts)
                .ThenInclude(x=>x.User)
                .ToListAsync();

            return _mapper.Map<List<ThreadDto>>(threads);
        }

        public async Task<ThreadDto> GetThreadAsync(int threadId)
        {
            var thread = await _context.Threads
                .Include(x => x.Posts)
                .ThenInclude(x => x.User)
                .Where(x => x.ThreadId == threadId)
                .FirstOrDefaultAsync();

            return _mapper.Map<ThreadDto>(thread);
        }
    }
}