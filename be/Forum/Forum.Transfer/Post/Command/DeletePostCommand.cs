using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Forum.Transfer.Post.Command
{
    public class DeletePostCommand : IRequest<int>
    {
        [Required] public int PostId { get; set; }
    }
}
