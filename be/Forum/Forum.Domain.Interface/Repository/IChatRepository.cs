using System.Threading.Tasks;
using Forum.Transfer.Chat.Data;
using Forum.Transfer.Chat.Query;
using Forum.Transfer.Shared;

namespace Forum.Domain.Interface.Repository
{
    public interface IChatRepository
    {
        Task EnsureExistsAsync(int messageId);
        Task<PageListDto<MessageDto>> GetMessageListAsync(GetAllMessagesQuery query);
        Task<MessageDto> GetMessageAsync(int messageId);
    }
}
