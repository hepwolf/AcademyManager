using AcademyManager.Domain.Entities;
using AcademyManager.Application.DTO;
using Microsoft.AspNetCore.Identity;

namespace AcademyManager.Domain.Repositories.CommandRepositories
{
    public interface IUserCommandRepository
    {
        Task AddUserAsync(UserAccount user);
        Task AddUserTokenAsync(UserToken userToken);    
        Task<bool> SaveChangesAsync();
    }
}

