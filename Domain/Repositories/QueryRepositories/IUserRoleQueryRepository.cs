using AcademyManager.Domain.Entities;

namespace AcademyManager.Domain.Repositories.QueryRepositories
{
    public interface IUserRoleQueryRepository:IGenericQueryRepository<UserRole,Guid>
    {
        Task<UserRole> GetUserRoleAsync(Guid userId, Guid roleId);
        Task<List<string>> GetUserRolesAsync(Guid userId);
        Task<List<string>> GetUserRoleIdsAsync(Guid userId);
    }
}
