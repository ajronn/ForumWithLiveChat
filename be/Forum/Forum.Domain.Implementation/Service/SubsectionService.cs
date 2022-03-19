using System.Threading.Tasks;
using AutoMapper;
using Forum.Data;
using Forum.Data.Entities;
using Forum.Domain.Interface.Repository;
using Forum.Domain.Interface.Service;
using Forum.Transfer.Subsection.Command;
using Forum.Transfer.Subsection.Data;
using Microsoft.EntityFrameworkCore;

namespace Forum.Domain.Implementation.Service
{
    public class SubsectionService : ISubsectionService
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISubsectionRepository _subsectionRepository;

        public SubsectionService(ForumDbContext context, IMapper mapper, ISubsectionRepository subsectionRepository)
        {
            _context = context;
            _mapper = mapper;
            _subsectionRepository = subsectionRepository;
        }

        public async Task<SubsectionDto> CreateAsync(CreateSubsectionCommand command)
        {
            var subsection = new Subsection
            {
                Name = command.Name,
                Description = command.Description,
                SectionId = command.SectionId
            };

            await _context.Subsections.AddAsync(subsection);
            await _context.SaveChangesAsync();
            return _mapper.Map<SubsectionDto>(subsection);
        }

        public async Task<SubsectionDto> UpdateAsync(UpdateSubsectionCommand command)
        {
            await _subsectionRepository.EnsureExistsAsync(command.SubsectionId);

            var subsection = await _context.Subsections.FirstOrDefaultAsync(x => x.SubsectionId == command.SubsectionId);

            subsection.Name = command.Name;
            subsection.Description = command.Description;

            await _context.SaveChangesAsync();
            return _mapper.Map<SubsectionDto>(subsection);
        }

        public async Task<int> DeleteAsync(DeleteSubsectionCommand command)
        {
            await _subsectionRepository.EnsureExistsAsync(command.SubsectionId);

            var subsection = await _context.Subsections.FirstOrDefaultAsync(x => x.SubsectionId == command.SubsectionId);

            _context.Remove(subsection);
            await _context.SaveChangesAsync();
            return subsection.SubsectionId;
        }
    }
}
