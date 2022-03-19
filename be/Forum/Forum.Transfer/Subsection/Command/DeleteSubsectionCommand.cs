using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Forum.Transfer.Subsection.Command
{
    public class DeleteSubsectionCommand : IRequest<int>
    {
        [Required] public int SubsectionId { get; set; }
    }
}
