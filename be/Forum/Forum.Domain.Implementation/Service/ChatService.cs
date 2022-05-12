using System;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Core;
using Forum.Data;
using Forum.Data.Entities;
using Forum.Domain.Interface.Repository;
using Forum.Domain.Interface.Service;
using Forum.Transfer.Chat.Command;
using Forum.Transfer.Chat.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Forum.Domain.Implementation.Service
{
    public class ChatService : IChatService
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;
        private readonly IChatRepository _chatRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChatService(ForumDbContext context, IMapper mapper, IChatRepository chatRepository, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _chatRepository = chatRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MessageDto> CreateAsync(CreateMessageCommand command)
        {
            var userId = _httpContextAccessor.HttpContext.GetUserId();

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            var message = new Message
            {
                Content = command.Content,
                CreatedAt = DateTime.Now,
                UserId = userId,
                UserName = user.UserName,
                IsArchival = false,
                User = user
            };

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            return _mapper.Map<MessageDto>(message);
        }
    }

    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(MessageDto message)
        {
            await Clients.All.ReceiveMessage(message);
        }
    }
}
