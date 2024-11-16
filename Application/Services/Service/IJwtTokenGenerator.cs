using AcademyManager.Domain.Entities;

namespace AcademyManager.Application.Services.Service
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateTokenAsync(UserAccount user);
    }
}
