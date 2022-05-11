using System;
using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Chat.Data;
using MediatR;

namespace Forum.Transfer.Chat.Command
{
    public class CreateMessageCommand : IRequest<MessageDto>
    {
        public string UserId { get; set; }

        [Required] public string UserName { get; set; }

        [Required] public string Content { get; set; }
    }
}
