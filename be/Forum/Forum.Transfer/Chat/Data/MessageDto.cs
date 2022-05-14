using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Transfer.Chat.Data
{
    public class MessageDto
    {
        public int MessageId { get; set; }

        public string UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Content { get; set; }

        public DateTime Date { get; set; }
    }
}
