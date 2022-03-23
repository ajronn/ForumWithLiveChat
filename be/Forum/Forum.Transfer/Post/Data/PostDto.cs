﻿using System;
using Forum.Transfer.Thread.Data;
using Forum.Transfer.User.Data;

namespace Forum.Transfer.Post.Data
{
    public class PostDto
    {
        public int PostId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime EditedAt { get; set; }

        public UserDto User { get; set; }

        public ThreadDto Thread { get; set; }
    }
}