using System.Collections.Generic;
using Forum.Transfer.Post.Data;
using MediatR;

namespace Forum.Transfer.Post.Query
{
    public class GetAllPostsQuery : IRequest<List<PostDto>>
    {
    }
}