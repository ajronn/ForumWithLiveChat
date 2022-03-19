using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Thread.Data;
using MediatR;

namespace Forum.Transfer.Thread.Command
{
    public class UpdateThreadCommand : IRequest<ThreadDto>
    {
        [Required] public int ThreadId { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Description { get; set; }
    }
}
