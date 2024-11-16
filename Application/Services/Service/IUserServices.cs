using AcademyManager.Application.DTO;
using AcademyManager.Domain.Entities;


namespace AcademyManager.Application.Services.Service
{
    public interface IUserServices
    {
        Task<UserAccount> RegisterUserAsync(RegisterUserDto registerDto);
        Task<string> LoginUserAsync(LoginUserDto loginDto);
    }
}
