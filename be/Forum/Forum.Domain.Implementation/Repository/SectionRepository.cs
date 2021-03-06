using System.Collections.Generic;
using System.Linq;
using Forum.Data;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Core;
using Forum.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Section.Data;

namespace Forum.Domain.Implementation.Repository
{
    public class SectionRepository : ISectionRepository
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;

        public SectionRepository(ForumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> ExistsAsync(int sectionId)
        {
            return _context.Sections
                .AnyAsync(x => x.SectionId == sectionId);
        }

        public async Task EnsureExistsAsync(int sectionId)
        {
            if (!await ExistsAsync(sectionId))
            {
                throw new ForumException(ForumErrorCode.SectionNotFound);
            }
        }


        public async Task<List<SectionDto>> GetSectionListAsync()
        {
            var sections = await _context.Sections
                .Include(x=>x.Subsections)
                .ToListAsync();

            return _mapper.Map<List<SectionDto>>(sections);
        }

        public async Task<SectionDto> GetSectionAsync(int sectionId)
        {
            var section = await _context.Sections
                .Include(x=>x.Subsections)
                .Where(x => x.SectionId == sectionId)
                .FirstOrDefaultAsync();

            return _mapper.Map<SectionDto>(section);
        }
    }
}