using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Section.Data;
using MediatR;

namespace Forum.Transfer.Section.Command
{
    public class UpdateSectionCommand : IRequest<SectionDto>
    {
        [Required] public int SectionId { get; set; }
        [Required] public string Name { get; set; }
    }
}
