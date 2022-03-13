using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Section;
using Forum.Transfer.Section.Query;
using MediatR;

namespace Forum.Handler.Section
{
    public class SectionQueryHandler : IRequestHandler<GetAllSectionQuery, List<SectionDto>>
    {
        private readonly ISectionRepository _sectionRepository;
        public SectionQueryHandler(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<List<SectionDto>> Handle(GetAllSectionQuery request, CancellationToken cancellationToken)
        {
            return await _sectionRepository.GetAsync();
        }
    }
}
