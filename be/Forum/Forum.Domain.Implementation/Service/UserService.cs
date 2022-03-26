using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Core;
using Forum.Core.Enums;
using Forum.Data;
using Forum.Data.Entities;
using Forum.Domain.Interface.Service;
using Forum.Transfer.User.Command;
using Forum.Transfer.User.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Forum.Domain.Implementation.Service
{
    public class UserService : IUserService
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;

        public UserService(ForumDbContext context, IMapper mapper, UserManager<User> userManager,
            IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<UserDto> CreateAsync(CreateUserCommand command)
        {
            var user = _mapper.Map<User>(command);
            user.IsActive = false;
            user.IsArchival = false;

            if (await _userManager.FindByEmailAsync(command.Email) != null)
            {
                throw new ForumException(ForumErrorCode.UserExists);
            }

            var result = await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                throw new ForumException(ForumErrorCode.RegisterFailed);
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<SessionDto> Login(LoginCommand command)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);
            if (user == null)
            {
                throw new ForumException(ForumErrorCode.UserNotFound);
            }

            if (!await _userManager.CheckPasswordAsync(user, command.Password))
            {
                throw new ForumException(ForumErrorCode.WrongPassword);
            }

            if (!user.IsActive)
            {
                throw new ForumException(ForumErrorCode.UserNotActive);
            }

            if (user.IsArchival)
            {
                throw new ForumException(ForumErrorCode.UserArchival);
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
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
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
                throw new ForumException(ForumErrorCode.UserNotFound);
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
                throw new ForumException(ForumErrorCode.UserNotFound);
            }

            user.IsActive = false;

            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> ArchiveAsync(ArchiveUserCommand command)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id);

            if (user == null)
            {
                throw new ForumException(ForumErrorCode.UserNotFound);
            }

            user.IsArchival = true;

            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> DearchiveAsync(DearchiveUserCommand command)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id);

            if (user == null)
            {
                throw new ForumException(ForumErrorCode.UserNotFound);
            }

            user.IsArchival = false;

            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }
    }
}