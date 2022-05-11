using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Service;
using Forum.Transfer.Chat.Command;
using Forum.Transfer.Chat.Data;
using MediatR;

namespace Forum.Handler.Chat
{
    public class ChatCommandHandler : IRequestHandler<CreateMessageCommand, MessageDto>
    {
        private readonly IChatService _chatService;

        public ChatCommandHandler(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task<MessageDto> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            return await _chatService.CreateAsync(request);
        }
    }
}
