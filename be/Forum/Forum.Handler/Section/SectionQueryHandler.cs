using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Section.Data;
using Forum.Transfer.Section.Query;
using MediatR;

namespace Forum.Handler.Section
{
    public class SectionQueryHandler : IRequestHandler<GetAllSectionsQuery, List<SectionDto>>,
        IRequestHandler<GetSectionQuery, SectionDto>
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionQueryHandler(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<List<SectionDto>> Handle(GetAllSectionsQuery request, CancellationToken cancellationToken)
        {
            return await _sectionRepository.GetSectionListAsync();
        }

        public async Task<SectionDto> Handle(GetSectionQuery request, CancellationToken cancellationToken)
        {
            return await _sectionRepository.GetSectionAsync(request.SectionId);
        }
    }
}