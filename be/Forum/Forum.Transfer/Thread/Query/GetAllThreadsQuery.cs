using System.Collections.Generic;
using Forum.Transfer.Thread.Data;
using MediatR;

namespace Forum.Transfer.Thread.Query
{
    public class GetAllThreadsQuery : IRequest<List<ThreadDto>>
    {
    }
}