using System.Threading.Tasks;
using Forum.Transfer.Chat.Command;
using Forum.Transfer.Chat.Data;

namespace Forum.Domain.Interface.Service
{
    public interface IChatService
    {
        Task<MessageDto> CreateAsync(CreateMessageCommand command);
    }

    public interface IChatClient
    {
        Task ReceiveMessage(MessageDto message);
    }
}
