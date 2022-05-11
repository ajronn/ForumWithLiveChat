using System.ComponentModel.DataAnnotations;
using Forum.Transfer.Chat.Data;
using MediatR;

namespace Forum.Transfer.Chat.Query
{
    public class GetMessageQuery : IRequest<MessageDto>
    {
        [Required] public int MessageId { get; set; }

        public GetMessageQuery(int messageId)
        {
            MessageId = messageId;
        }
    }
}
