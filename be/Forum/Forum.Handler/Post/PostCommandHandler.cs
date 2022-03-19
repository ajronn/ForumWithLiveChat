using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Repository;
using Forum.Domain.Interface.Service;
using Forum.Transfer.Post.Command;
using Forum.Transfer.Post.Data;
using MediatR;

namespace Forum.Handler.Post
{
    public class PostCommandHandler : IRequestHandler<CreatePostCommand, PostDto>,
        IRequestHandler<UpdatePostCommand, PostDto>, IRequestHandler<DeletePostCommand, int>
    {
        private readonly IPostService _postService;

        public PostCommandHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<PostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            return await _postService.CreateAsync(request);
        }

        public async Task<PostDto> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            return await _postService.UpdateAsync(request);
        }

        public async Task<int> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            return await _postService.DeleteAsync(request);
        }
    }
}