using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class Message
    {
        [Key] public int MessageId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public User User { get; set; }

        public bool IsArchival { get; set; }
    }
}
