using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Core;
using Forum.Core.Enums;
using Forum.Data;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Role.Data;
using Forum.Transfer.User.Data;
using Microsoft.EntityFrameworkCore;

namespace Forum.Domain.Implementation.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;


        public RoleRepository(ForumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> ExistsAsync(string roleId)
        {
            return _context.Roles
                .AnyAsync(x => x.Id == roleId);
        }

        public async Task EnsureExistsAsync(string roleId)
        {
            if (!await ExistsAsync(roleId))
            {
                throw new ForumException(ForumErrorCode.RoleNotFound);
            }
        }

        public async Task<List<RoleDto>> GetRoleListAsync()
        {
            var roles = await _context.Roles
                .ToListAsync();

            return _mapper.Map<List<RoleDto>>(roles);
        }

        public async Task<RoleDto> GetRoleAsync(string roleId)
        {
            var role = await _context.Roles
                .Where(x => x.Id == roleId)
                .FirstOrDefaultAsync();

            return _mapper.Map<RoleDto>(role);
        }
    }
}
