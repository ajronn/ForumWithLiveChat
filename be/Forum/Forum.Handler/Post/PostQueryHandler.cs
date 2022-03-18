using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Post.Data;
using Forum.Transfer.Post.Query;
using MediatR;

namespace Forum.Handler.Post
{
    public class PostQueryHandler : IRequestHandler<GetAllPostsQuery, List<PostDto>>,
        IRequestHandler<GetPostQuery, PostDto>
    {
        private readonly IPostRepository _postRepository;

        public PostQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<PostDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            return await _postRepository.GetPostListAsync();
        }

        public async Task<PostDto> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            return await _postRepository.GetPostAsync(request.PostId);
        }
    }
}