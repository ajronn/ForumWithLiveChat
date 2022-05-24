using System.Threading.Tasks;
using AutoMapper;
using Forum.Core;
using Forum.Core.Enums;
using Forum.Data;
using Forum.Domain.Interface.Repository;
using Forum.Domain.Interface.Service;
using Forum.Transfer.Role.Command;
using Forum.Transfer.Role.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Forum.Domain.Implementation.Service
{
    public class RoleService : IRoleService
    {
        private readonly ForumDbContext _context;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(ForumDbContext context, IMapper mapper, IRoleRepository roleRepository, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _roleRepository = roleRepository;
            _roleManager = roleManager;
        }

        public async Task<RoleDto> CreateAsync(CreateRoleCommand command)
        {
            var role = new IdentityRole
            {
                Name = command.Name
            };

            await _roleManager.CreateAsync(role);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> UpdateAsync(UpdateRoleCommand command)
        {
            await _roleRepository.EnsureExistsAsync(command.RoleId);

            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == command.RoleId);

            if (role.Name == "Administrator" || role.Name == "Użytkownik")
            {
                throw new ForumException(ForumErrorCode.RoleCannotBeChanged);
            }

            role.Name = command.Name;

            await _roleManager.UpdateAsync(role);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<string> DeleteAsync(DeleteRoleCommand command)
        {
            await _roleRepository.EnsureExistsAsync(command.RoleId);

            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == command.RoleId);

            if (role.Name == "Administrator" || role.Name == "Użytkownik")
            {
                throw new ForumException(ForumErrorCode.RoleCannotBeChanged);
            }

            await _roleManager.DeleteAsync(role);
            return role.Id;
        }
    }
}
