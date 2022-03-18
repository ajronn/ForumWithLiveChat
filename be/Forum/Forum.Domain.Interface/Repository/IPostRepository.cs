using System.Collections.Generic;
using System.Threading.Tasks;
using Forum.Transfer.Post.Data;

namespace Forum.Domain.Interface.Repository
{
    public interface IPostRepository
    {
        Task EnsureExistsAsync(int postId);
        Task<List<PostDto>> GetPostListAsync();
        Task<PostDto> GetPostAsync(int postId);
    }
}
