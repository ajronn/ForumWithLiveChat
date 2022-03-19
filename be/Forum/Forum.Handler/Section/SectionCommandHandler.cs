using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Service;
using Forum.Transfer.Section.Command;
using Forum.Transfer.Section.Data;
using MediatR;

namespace Forum.Handler.Section
{
    public class SectionCommandHandler : IRequestHandler<CreateSectionCommand, SectionDto>,
        IRequestHandler<UpdateSectionCommand, SectionDto>, IRequestHandler<DeleteSectionCommand, int>
    {
        private readonly ISectionService _sectionService;

        public SectionCommandHandler(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        public async Task<SectionDto> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
        {
            return await _sectionService.CreateAsync(request);
        }

        public async Task<SectionDto> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
        {
            return await _sectionService.UpdateAsync(request);
        }

        public async Task<int> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
        {
            return await _sectionService.DeleteAsync(request);
        }
    }
}
