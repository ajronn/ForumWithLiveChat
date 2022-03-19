using System.Threading.Tasks;
using Forum.Transfer.Thread.Command;
using Forum.Transfer.Thread.Data;

namespace Forum.Domain.Interface.Service
{
    public interface IThreadService
    {
        Task<ThreadDto> CreateAsync(CreateThreadCommand command);
        Task<ThreadDto> UpdateAsync(UpdateThreadCommand command);
        Task<int> DeleteAsync(DeleteThreadCommand command);
    }
}
