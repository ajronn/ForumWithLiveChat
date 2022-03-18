using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Post.Data;
using MediatR;

namespace Forum.Transfer.Post.Query
{
    public class GetPostQuery : IRequest<PostDto>
    {
        [Required] public int PostId { get; set; }

        public GetPostQuery(int postId)
        {
            PostId = postId;
        }
    }
}