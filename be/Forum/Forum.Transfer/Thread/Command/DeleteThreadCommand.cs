using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Forum.Transfer.Thread.Command
{
    public class DeleteThreadCommand : IRequest<int>
    {
        [Required] public int ThreadId { get; set; }
    }
}
