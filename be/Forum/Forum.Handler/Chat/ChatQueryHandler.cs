using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Chat;
using Forum.Transfer.Chat.Data;
using Forum.Transfer.Chat.Query;
using Forum.Transfer.Post.Data;
using Forum.Transfer.Post.Query;
using MediatR;

namespace Forum.Handler.Chat
{
    public class ChatQueryHandler : IRequestHandler<GetAllMessagesQuery, List<MessageDto>>,
        IRequestHandler<GetMessageQuery, MessageDto>
    {
        private readonly IChatRepository _chatRepository;

        public ChatQueryHandler(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<List<MessageDto>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            return await _chatRepository.GetMessageListAsync();
        }

        public async Task<MessageDto> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            return await _chatRepository.GetMessageAsync(request.MessageId);
        }
    }
}
