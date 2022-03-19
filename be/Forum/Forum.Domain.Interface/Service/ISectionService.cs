using System.Threading.Tasks;
using Forum.Transfer.Section.Command;
using Forum.Transfer.Section.Data;

namespace Forum.Domain.Interface.Service
{
    public interface ISectionService
    {
        Task<SectionDto> CreateAsync(CreateSectionCommand command);
        Task<SectionDto> UpdateAsync(UpdateSectionCommand command);
        Task<int> DeleteAsync(DeleteSectionCommand command);
    }
}
