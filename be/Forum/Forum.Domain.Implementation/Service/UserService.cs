using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Core;
using Forum.Data;
using Forum.Data.Entities;
using Forum.Domain.Interface.Service;
using Forum.Transfer.User.Command;
using Forum.Transfer.User.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Forum.Domain.Implementation.Service
{
    public class UserService : IUserService
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;

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

            if (await _userManager.FindByEmailAsync(command.Email) != null)
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

        public async Task<SessionDto> Login(LoginCommand command)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);
            if (user == null)
            {
                //exception użytkownik nie istnieje
            }

            if (!await _userManager.CheckPasswordAsync(user, command.Password))
            {
                //exception złe hasło
            }

            if (!user.IsActive)
            {
                //exception użytkownik nie jest aktywny
            }

            if (user.IsArchival)
            {
                //exception użytkownik jest zarchiwizowany
            }

            return new SessionDto
            {
                Token = GenerateSessionTokenForUser(user),
                User = _mapper.Map<UserDto>(user)
            };
        }

        private string GenerateSessionTokenForUser(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaa");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("id", user.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<UserDto> ActivateAsync(ActivateUserCommand command)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id);

            if (user == null)
            {
                //exception użytkownik nie istnieje
            }

            user.IsActive = true;
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> DeactivateAsync(DeactivateUserCommand command)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id);

            if (user == null)
            {
                //exception użytkownik nie istnieje
            }

            user.IsActive = false;

            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task ArchiveAsync(ArchiveUserCommand command)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id);

            if (user == null)
            {
                //exception użytkownik nie istnieje
            }

            user.IsArchival = true;

            await _context.SaveChangesAsync();
        }

        public async Task DearchiveAsync(DearchiveUserCommand command)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id);

            if (user == null)
            {
                //exception użytkownik nie istnieje
            }

            user.IsArchival = false;

            await _context.SaveChangesAsync();
        }
    }
}