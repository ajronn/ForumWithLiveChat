using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Thread.Data;
using MediatR;

namespace Forum.Transfer.Thread.Command
{
    public class CreateThreadCommand : IRequest<ThreadDto>
    {
        [Required] public string Name { get; set; }

        [Required] public string Description { get; set; }

        [Required] public int SubsectionId { get; set; }
    }
}