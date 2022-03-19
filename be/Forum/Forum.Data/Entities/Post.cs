using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class Post
    {
        [Key] public int PostId { get; set; }

        public string Content { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? EditedAt { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int ThreadId { get; set; }

        public Thread Thread { get; set; }
    }
}