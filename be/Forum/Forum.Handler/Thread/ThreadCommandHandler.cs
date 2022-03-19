using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Service;
using Forum.Transfer.Thread.Command;
using Forum.Transfer.Thread.Data;
using MediatR;

namespace Forum.Handler.Thread
{
    public class ThreadCommandHandler : IRequestHandler<CreateThreadCommand, ThreadDto>,
        IRequestHandler<UpdateThreadCommand, ThreadDto>, IRequestHandler<DeleteThreadCommand, int>
    {
        private readonly IThreadService _threadService;

        public ThreadCommandHandler(IThreadService threadService)
        {
            _threadService = threadService;
        }

        public async Task<ThreadDto> Handle(CreateThreadCommand request, CancellationToken cancellationToken)
        {
            return await _threadService.CreateAsync(request);
        }

        public async Task<ThreadDto> Handle(UpdateThreadCommand request, CancellationToken cancellationToken)
        {
            return await _threadService.UpdateAsync(request);
        }

        public async Task<int> Handle(DeleteThreadCommand request, CancellationToken cancellationToken)
        {
            return await _threadService.DeleteAsync(request);
        }
    }
}
