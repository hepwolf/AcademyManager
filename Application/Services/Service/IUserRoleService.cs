using AcademyManager.Application.DTO;

namespace AcademyManager.Application.Services.Service
{
    public interface IUserRoleService
    {
        Task<Guid?> AssignRoleToUserAsync(UserRoleDto userRoleDto);
        Task<bool> RemoveRoleFromUserAsync(UserRoleDto userRoleDto);
        Task<List<string>> GetUserRolesAsync(Guid userId);
        Task<List<string>> GetUserRoleIdsAsync(Guid userId);
    }
}
