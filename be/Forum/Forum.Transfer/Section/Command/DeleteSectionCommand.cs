using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Forum.Transfer.Section.Command
{
    public class DeleteSectionCommand : IRequest<int>
    {
        [Required] public int SectionId { get; set; }
    }
}
