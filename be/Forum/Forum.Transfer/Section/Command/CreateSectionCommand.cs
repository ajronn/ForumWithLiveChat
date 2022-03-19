using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Section.Data;
using MediatR;

namespace Forum.Transfer.Section.Command
{
    public class CreateSectionCommand : IRequest<SectionDto>
    {
        [Required] public string Name { get; set; }
    }
}