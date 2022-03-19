using System.Threading.Tasks;
using AutoMapper;
using Forum.Data;
using Forum.Data.Entities;
using Forum.Domain.Interface.Repository;
using Forum.Domain.Interface.Service;
using Forum.Transfer.Thread.Command;
using Forum.Transfer.Thread.Data;
using Microsoft.EntityFrameworkCore;

namespace Forum.Domain.Implementation.Service
{
    public class ThreadService : IThreadService
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;
        private readonly IThreadRepository _threadRepository;

        public ThreadService(ForumDbContext context, IMapper mapper, IThreadRepository threadRepository)
        {
            _context = context;
            _mapper = mapper;
            _threadRepository = threadRepository;
        }

        public async Task<ThreadDto> CreateAsync(CreateThreadCommand command)
        {
            var thread = new Thread
            {
                Name = command.Name,
                Description = command.Description
            };

            await _context.Threads.AddAsync(thread);
            await _context.SaveChangesAsync();
            return _mapper.Map<ThreadDto>(thread);
        }

        public async Task<ThreadDto> UpdateAsync(UpdateThreadCommand command)
        {
            await _threadRepository.EnsureExistsAsync(command.ThreadId);

            var thread = await _context.Threads.FirstOrDefaultAsync(x => x.ThreadId == command.ThreadId);

            thread.Name = command.Name;
            thread.Description = command.Description;

            await _context.SaveChangesAsync();
            return _mapper.Map<ThreadDto>(thread);
        }

        public async Task<int> DeleteAsync(DeleteThreadCommand command)
        {
            await _threadRepository.EnsureExistsAsync(command.ThreadId);

            var thread = await _context.Threads.FirstOrDefaultAsync(x => x.ThreadId == command.ThreadId);

            _context.Remove(thread);
            await _context.SaveChangesAsync();
            return thread.ThreadId;
        }
    }
}
