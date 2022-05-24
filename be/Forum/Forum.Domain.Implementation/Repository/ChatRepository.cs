using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Core;
using Forum.Core.Enums;
using Forum.Data;
using Forum.Domain.Implementation.Extensions;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Chat.Data;
using Forum.Transfer.Chat.Query;
using Forum.Transfer.Shared;
using Microsoft.EntityFrameworkCore;

namespace Forum.Domain.Implementation.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;

        public ChatRepository(ForumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> ExistsAsync(int messageId)
        {
            return _context.Messages
                .AnyAsync(x => x.MessageId == messageId);
        }

        public async Task EnsureExistsAsync(int messageId)
        {
            if (!await ExistsAsync(messageId))
            {
                throw new ForumException(ForumErrorCode.MessageNotFound);
            }
        }

        public async Task<PageListDto<MessageDto>> GetMessageListAsync(GetAllMessagesQuery query)
        {
            var messages = await _context.Messages
                .ToPagedListAsync(query);

            return _mapper.Map<PageListDto<MessageDto>>(messages);
        }

        public async Task<MessageDto> GetMessageAsync(int messageId)
        {
            var message = await _context.Messages
                .Where(x => x.MessageId == messageId)
                .FirstOrDefaultAsync();

            return _mapper.Map<MessageDto>(message);
        }
    }
}
