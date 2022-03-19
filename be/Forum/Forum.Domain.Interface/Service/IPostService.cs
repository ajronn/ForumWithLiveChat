using System.Threading.Tasks;
using Forum.Transfer.Post.Command;
using Forum.Transfer.Post.Data;

namespace Forum.Domain.Interface.Service
{
    public interface IPostService
    {
        Task<PostDto> CreateAsync(CreatePostCommand command);
        Task<PostDto> UpdateAsync(UpdatePostCommand command);
        Task<int> DeleteAsync(DeletePostCommand command);
    }
}
