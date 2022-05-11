using System.Collections.Generic;
using Forum.Transfer.Chat.Data;
using MediatR;

namespace Forum.Transfer.Chat.Query
{
    public class GetAllMessagesQuery : IRequest<List<MessageDto>>
    {
    }
}
