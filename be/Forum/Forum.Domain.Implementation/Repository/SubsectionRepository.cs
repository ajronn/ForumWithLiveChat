using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Data;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Subsection.Data;
using Microsoft.EntityFrameworkCore;

namespace Forum.Domain.Implementation.Repository
{
    public class SubsectionRepository : ISubsectionRepository
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;

        public SubsectionRepository(ForumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> ExistsAsync(int subsectionId)
        {
            return _context.Subsections
                .AnyAsync(x => x.SubsectionId == subsectionId);
        }

        public async Task EnsureExistsAsync(int subsectionId)
        {
            if (!await ExistsAsync(subsectionId))
                //do późniejszej implementacji wraz z enum błędami
                throw null;
        }


        public async Task<List<SubsectionDto>> GetSubsectionListAsync()
        {
            var subsections = await _context.Subsections
                .Include(x => x.Threads).ToListAsync();
            return _mapper.Map<List<SubsectionDto>>(subsections);
        }

        public async Task<SubsectionDto> GetSubsectionAsync(int subsectionId)
        {
            var subsection = await _context.Subsections
                .Include(x => x.Threads)
                .Where(x => x.SubsectionId == subsectionId)
                .FirstOrDefaultAsync();

            return _mapper.Map<SubsectionDto>(subsection);
        }
    }
}