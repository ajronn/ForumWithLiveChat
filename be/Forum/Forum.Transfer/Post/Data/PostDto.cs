using System;
using Forum.Transfer.Thread.Data;
using Forum.Transfer.User.Data;

namespace Forum.Transfer.Post.Data
{
    public class PostDto
    {
        public int PostId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? EditedAt { get; set; }

        public string UserId { get; set; }

        public UserBasicDto User { get; set; }

        public int ThreadId { get; set; }

        public ThreadDto Thread { get; set; }
    }
}