using System.Collections.Generic;
using System.Threading.Tasks;
using Forum.Transfer.Thread.Data;

namespace Forum.Domain.Interface.Repository
{
    public interface IThreadRepository
    {
        Task EnsureExistsAsync(int threadId);
        Task<List<ThreadDto>> GetThreadListAsync();
        Task<ThreadDto> GetThreadAsync(int threadId);
    }
}
