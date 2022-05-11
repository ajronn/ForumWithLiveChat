using System.Collections.Generic;
using System.Threading.Tasks;
using Forum.Transfer.Chat.Data;

namespace Forum.Domain.Interface.Repository
{
    public interface IChatRepository
    {
        Task EnsureExistsAsync(int messageId);
        Task<List<MessageDto>> GetMessageListAsync();
        Task<MessageDto> GetMessageAsync(int messageId);
    }
}
