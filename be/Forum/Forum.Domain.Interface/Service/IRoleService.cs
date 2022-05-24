using System.Threading.Tasks;
using Forum.Transfer.Role.Command;
using Forum.Transfer.Role.Data;

namespace Forum.Domain.Interface.Service
{
    public interface IRoleService
    {
        Task<RoleDto> CreateAsync(CreateRoleCommand command);
        Task<RoleDto> UpdateAsync(UpdateRoleCommand command);
        Task<string> DeleteAsync(DeleteRoleCommand command);
    }
}
