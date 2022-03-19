using System.Threading.Tasks;
using Forum.Transfer.Subsection.Command;
using Forum.Transfer.Subsection.Data;

namespace Forum.Domain.Interface.Service
{
    public interface ISubsectionService
    {
        Task<SubsectionDto> CreateAsync(CreateSubsectionCommand command);
        Task<SubsectionDto> UpdateAsync(UpdateSubsectionCommand command);
        Task<int> DeleteAsync(DeleteSubsectionCommand command);
    }
}
