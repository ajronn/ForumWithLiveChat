using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Post.Data;
using MediatR;

namespace Forum.Transfer.Post.Command
{
    public class UpdatePostCommand : IRequest<PostDto>
    {
        [Required] public int PostId { get; set; }
        [Required] public string Content { get; set; }
    }
}