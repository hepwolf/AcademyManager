

using AcademyManager.Domain.Entities;

namespace AcademyManager.Domain.Repositories.QueryRepositories
{
    public interface IUserQueryRepository:IGenericQueryRepository<UserAccount,Guid>
    {
        Task<UserAccount> GetUserByEmailAsync(string email);
        Task<UserAccount> GetUserByUsernameAsync(string userName);
        Task<UserToken> GetUserTokenAsync(string token);

    }
}
