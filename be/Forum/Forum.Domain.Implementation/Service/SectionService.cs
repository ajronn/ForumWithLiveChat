using System.Threading.Tasks;
using AutoMapper;
using Forum.Data;
using Forum.Data.Entities;
using Forum.Domain.Interface.Repository;
using Forum.Domain.Interface.Service;
using Forum.Transfer.Section.Command;
using Forum.Transfer.Section.Data;
using Microsoft.EntityFrameworkCore;

namespace Forum.Domain.Implementation.Service
{
    public class SectionService : ISectionService
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISectionRepository _sectionRepository;

        public SectionService(ForumDbContext context, IMapper mapper, ISectionRepository sectionRepository)
        {
            _context = context;
            _mapper = mapper;
            _sectionRepository = sectionRepository;
        }

        public async Task<SectionDto> CreateAsync(CreateSectionCommand command)
        {
            var section = new Section
            {
                Name = command.Name
            };

            await _context.Sections.AddAsync(section);
            await _context.SaveChangesAsync();
            return _mapper.Map<SectionDto>(section);
        }

        public async Task<SectionDto> UpdateAsync(UpdateSectionCommand command)
        {
            await _sectionRepository.EnsureExistsAsync(command.SectionId);

            var section = await _context.Sections.FirstOrDefaultAsync(x => x.SectionId == command.SectionId);

            section.Name = command.Name;

            await _context.SaveChangesAsync();
            return _mapper.Map<SectionDto>(section);
        }

        public async Task<int> DeleteAsync(DeleteSectionCommand command)
        {
            await _sectionRepository.EnsureExistsAsync(command.SectionId);

            var section = await _context.Sections.FirstOrDefaultAsync(x => x.SectionId == command.SectionId);

            _context.Remove(section);
            await _context.SaveChangesAsync();
            return section.SectionId;
        }
    }
}
