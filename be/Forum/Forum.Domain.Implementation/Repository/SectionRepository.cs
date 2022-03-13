using System.Collections.Generic;
using Forum.Data;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Transfer.Section;
using Microsoft.EntityFrameworkCore;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Section.Query;

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

        public async Task<List<SectionDto>> GetAsync()
        {
            var sections = await _context.Sections.ToListAsync();
            return _mapper.Map<List<SectionDto>>(sections);
        }

    }
}
