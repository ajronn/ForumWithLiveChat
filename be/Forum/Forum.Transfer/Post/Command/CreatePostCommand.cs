using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Post.Data;
using MediatR;

namespace Forum.Transfer.Post.Command
{
    public class CreatePostCommand : IRequest<PostDto>
    {
        [Required] public string Content { get; set; }

        [Required] public int ThreadId { get; set; }
    }
}