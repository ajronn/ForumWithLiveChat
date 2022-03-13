using System.Collections.Generic;
using System.Threading.Tasks;
using Forum.Transfer.Section;
using Forum.Transfer.Section.Query;

namespace Forum.Domain.Interface.Repository
{
    public interface ISectionRepository
    {
        Task<List<SectionDto>> GetAsync();
    }
}
