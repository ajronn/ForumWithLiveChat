using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Service;
using Forum.Transfer.Subsection.Command;
using Forum.Transfer.Subsection.Data;
using MediatR;

namespace Forum.Handler.Subsection
{
    public class SubsectionCommandHandler : IRequestHandler<CreateSubsectionCommand, SubsectionDto>,
        IRequestHandler<UpdateSubsectionCommand, SubsectionDto>, IRequestHandler<DeleteSubsectionCommand, int>
    {
        private readonly ISubsectionService _subsectionService;

        public SubsectionCommandHandler(ISubsectionService subsectionService)
        {
            _subsectionService = subsectionService;
        }

        public async Task<SubsectionDto> Handle(CreateSubsectionCommand request, CancellationToken cancellationToken)
        {
            return await _subsectionService.CreateAsync(request);
        }

        public async Task<SubsectionDto> Handle(UpdateSubsectionCommand request, CancellationToken cancellationToken)
        {
            return await _subsectionService.UpdateAsync(request);
        }

        public async Task<int> Handle(DeleteSubsectionCommand request, CancellationToken cancellationToken)
        {
            return await _subsectionService.DeleteAsync(request);
        }
    }
}
