using System.Collections.Generic;
using System.Threading.Tasks;
using Forum.Transfer.Section.Data;

namespace Forum.Domain.Interface.Repository
{
    public interface ISectionRepository
    {
        Task EnsureExistsAsync(int sectionId);
        Task<List<SectionDto>> GetSectionListAsync();
        Task<SectionDto> GetSectionAsync(int sectionId);
    }
}