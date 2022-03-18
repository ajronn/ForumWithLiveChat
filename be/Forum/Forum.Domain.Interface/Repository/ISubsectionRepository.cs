using System.Collections.Generic;
using System.Threading.Tasks;
using Forum.Transfer.Subsection.Data;

namespace Forum.Domain.Interface.Repository
{
    public interface ISubsectionRepository
    {
        Task EnsureExistsAsync(int subsectionId);
        Task<List<SubsectionDto>> GetSubsectionListAsync();
        Task<SubsectionDto> GetSubsectionAsync(int subsectionId);
    }
}
