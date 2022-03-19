using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Subsection.Data;
using MediatR;

namespace Forum.Transfer.Subsection.Command
{
    public class UpdateSubsectionCommand : IRequest<SubsectionDto>
    {
        [Required] public int SubsectionId { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Description { get; set; }
    }
}