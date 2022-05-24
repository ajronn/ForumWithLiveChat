using System.Collections.Generic;
using System.Threading.Tasks;
using Forum.Transfer.Role.Data;

namespace Forum.Domain.Interface.Repository
{
    public interface IRoleRepository
    {
        Task EnsureExistsAsync(string roleId);
        Task<List<RoleDto>> GetRoleListAsync();
        Task<RoleDto> GetRoleAsync(string roleId);
    }
}
