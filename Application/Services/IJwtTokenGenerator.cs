using AcademyManager.Domain.Entities;

namespace AcademyManager.Application.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(UserAccount user);
    }
}
