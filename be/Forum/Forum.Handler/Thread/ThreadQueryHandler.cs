using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Thread.Data;
using Forum.Transfer.Thread.Query;
using MediatR;

namespace Forum.Handler.Thread
{
    public class ThreadQueryHandler : IRequestHandler<GetAllThreadsQuery, List<ThreadDto>>,
        IRequestHandler<GetThreadQuery, ThreadDto>
    {
        private readonly IThreadRepository _threadRepository;

        public ThreadQueryHandler(IThreadRepository threadRepository)
        {
            _threadRepository = threadRepository;
        }

        public async Task<List<ThreadDto>> Handle(GetAllThreadsQuery request, CancellationToken cancellationToken)
        {
            return await _threadRepository.GetThreadListAsync();
        }

        public async Task<ThreadDto> Handle(GetThreadQuery request, CancellationToken cancellationToken)
        {
            return await _threadRepository.GetThreadAsync(request.ThreadId);
        }
    }
}