using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Chat.Data;
using Forum.Transfer.Chat.Query;
using Forum.Transfer.Shared;
using MediatR;

namespace Forum.Handler.Chat
{
    public class ChatQueryHandler : IRequestHandler<GetAllMessagesQuery, PageListDto<MessageDto>>,
        IRequestHandler<GetMessageQuery, MessageDto>
    {
        private readonly IChatRepository _chatRepository;

        public ChatQueryHandler(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<PageListDto<MessageDto>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            return await _chatRepository.GetMessageListAsync(request);
        }

        public async Task<MessageDto> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            return await _chatRepository.GetMessageAsync(request.MessageId);
        }
    }
}
