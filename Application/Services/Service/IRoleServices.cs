using AcademyManager.Application.DTO;
using AcademyManager.Domain.Entities;
using static Chessie.ErrorHandling.AsyncExtensions;

namespace AcademyManager.Application.Services.Service
{
    public interface IRoleServices
    {
        Task<Guid> AddRoleAsync(RoleDto roleDto);
        Task<bool> DeleteRoleAsync(Guid roleId);
        Task<IEnumerable<RoleDto>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(Guid roleId);
        Task<string> GetRoleNameByIdAsync(Guid roleId);
    }
}
