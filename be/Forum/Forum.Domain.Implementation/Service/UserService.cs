using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Data;
using Forum.Data.Entities;
using Forum.Domain.Interface.Service;
using Forum.Transfer.User.Command;
using Forum.Transfer.User.Data;
using Microsoft.AspNetCore.Identity;

namespace Forum.Domain.Implementation.Service
{
    public class UserService : IUserService
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(ForumDbContext context, IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UserDto> CreateAsync(CreateUserCommand command)
        {
            var user = _mapper.Map<User>(command);
            user.IsActive = false;
            user.IsArchival = false;

            if (_context.Users.Any(x => x.Email == user.Email))
            {
                //exception użytkownik już istnieje
            }

            var result = await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                //exception rejestracja failed
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}
