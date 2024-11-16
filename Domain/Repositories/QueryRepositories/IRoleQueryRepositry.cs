using AcademyManager.Domain.Entities;

namespace AcademyManager.Domain.Repositories.QueryRepositories
{
    public interface IRoleQueryRepositry:IGenericQueryRepository<Role,Guid>
    {
        Task<string> GetRoleNameById(Guid roleId);
    }
}
