using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Subsection.Data;
using MediatR;

namespace Forum.Transfer.Subsection.Query
{
    public class GetSubsectionQuery : IRequest<SubsectionDto>
    {
        [Required] public int SubsectionId { get; set; }

        public GetSubsectionQuery(int subsectionId)
        {
            SubsectionId = subsectionId;
        }
    }
}