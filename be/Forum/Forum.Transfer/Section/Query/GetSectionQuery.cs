using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Section.Data;
using MediatR;

namespace Forum.Transfer.Section.Query
{
    public class GetSectionQuery : IRequest<SectionDto>
    {
        [Required] public int SectionId { get; set; }

        public GetSectionQuery(int sectionId)
        {
            SectionId = sectionId;
        }
    }
}