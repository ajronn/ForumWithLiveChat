using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Thread.Data;
using MediatR;

namespace Forum.Transfer.Thread.Query
{
    public class GetThreadQuery : IRequest<ThreadDto>
    {
        [Required] public int ThreadId { get; set; }

        public GetThreadQuery(int threadId)
        {
            ThreadId = threadId;
        }
    }
}