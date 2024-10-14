using AcademyManager.Domain.Entities;
using AcademyManager.Application.DTO;

namespace AcademyManager.Application.Services
{
    public interface IUserServices
    {
        Task<UserAccount> RegisterUserAsync(RegisterUserDto registerDto);
        Task<string> LoginUserAsync(LoginUserDto loginDto);

    }
}
