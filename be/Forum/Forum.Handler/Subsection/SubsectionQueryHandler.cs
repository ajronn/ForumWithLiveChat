using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Subsection.Data;
using Forum.Transfer.Subsection.Query;
using MediatR;

namespace Forum.Handler.Subsection
{
    public class SubsectionQueryHandler : IRequestHandler<GetAllSubsectionsQuery, List<SubsectionDto>>,
        IRequestHandler<GetSubsectionQuery, SubsectionDto>
    {
        private readonly ISubsectionRepository _subsectionRepository;

        public SubsectionQueryHandler(ISubsectionRepository subsectionRepository)
        {
            _subsectionRepository = subsectionRepository;
        }

        public async Task<List<SubsectionDto>> Handle(GetAllSubsectionsQuery request,
            CancellationToken cancellationToken)
        {
            return await _subsectionRepository.GetSubsectionListAsync();
        }

        public async Task<SubsectionDto> Handle(GetSubsectionQuery request, CancellationToken cancellationToken)
        {
            return await _subsectionRepository.GetSubsectionAsync(request.SubsectionId);
        }
    }
}